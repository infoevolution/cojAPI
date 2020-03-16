using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using cojApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cojApi.Controllers {
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class cojIntegrationsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojIntegrationsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojIntegration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegration>>> GetAllItem () {

            try {
                var _cojIntegration = await _context.cojIntegrations.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegration.Count != 0) {
                    return Ok (_cojIntegration);
                }
                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        //GET: api/cojIntegration/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegration>>> GetAll () {

            try {
                var _cojIntegration = await _context.cojIntegrations.OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegration.Count != 0) {
                    return Ok (_cojIntegration);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojIntegration/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegration>>> GetHistory (long id) {

            try {
                var _cojIntegration = await _context.cojIntegrations.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if (_cojIntegration.Count != 0) {
                    return Ok (_cojIntegration);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojIntegration/searchName
        [Route ("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegration>>> searchName (string term) {

            try {
                var _cojIntegration = await _context.cojIntegrations.Where (x => x.name.ToLowerInvariant ().Contains (term) &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.id).ToListAsync ();

                if (_cojIntegration.Count != 0) {
                    return Ok (_cojIntegration);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // GET: api/cojIntegration/bgPlan
        [Route ("[action]/{bgPlanId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegration>>> bgPlan (double bgPlanId) {

            try {
                var _cojIntegration = await _context.cojIntegrations.Where (x => x.cojBGPlanId == bgPlanId &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.id).ToListAsync ();

                if (_cojIntegration.Count != 0) {
                    return Ok (_cojIntegration);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // GET: api/cojIntegration/bgPlanAgency
        [Route ("[action]/{bgPlanId}/{cojAgencyId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegration>>> bgPlanAgency (double bgPlanId, double cojAgencyId) {

            try {
                var _cojIntegration = await _context.cojIntegrations.Where (x => x.cojBGPlanId == bgPlanId &&
                    x.cojAgencyId == cojAgencyId &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.id).ToListAsync ();

                if (_cojIntegration.Count != 0) {
                    return Ok (_cojIntegration);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // GET: api/cojIntegration/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojIntegration>> GetItem (long id) {

            try {
                var cojIntegration = await _context.cojIntegrations.FindAsync (id);

                if (cojIntegration == null) {

                    return NoContent ();

                }

                return Ok (cojIntegration);

            } catch (Exception ex) {

                return BadRequest (ex.Message);
            }

        }

        // POST: api/cojIntegration
        [HttpPost]
        public async Task<ActionResult<cojIntegration>> CreateItem (cojIntegration newItem) {

            try {
                //check duplicate item id, code, name
                if (newItem.id != 0) {

                    return NoContent ();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojIntegrations.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojIntegrations.FindAsync (newItem.id);
                // _item.startDate = DateTime.Now.ToString (_culture);
                // _item.endDate = "31/12/9999 00:00:00";
                // _item.idRef = newItem.id;
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        [Route ("[action]")] // POST MORE Row: api/cojIntegration/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojIntegration>>> UploadItem (cojIntegration[] newItems) {

            try {
                foreach (var _itm in newItems) {

                    cojIntegration newItem = new cojIntegration {
                        idRef = 0,
                        name = _itm.name,
                        cojBGPlanId = _itm.cojBGPlanId,
                        cojWorkplanTypeId = _itm.cojWorkplanTypeId,
                        cojBGWorkplanId = _itm.cojBGWorkplanId,
                        cojWorkActivityId = _itm.cojWorkActivityId,
                        cojWorkActivityItemId = _itm.cojWorkActivityItemId,
                        cojBudgetType = _itm.cojBudgetType,
                        cojAgencyId = _itm.cojAgencyId,
                        cojBGPlanAMT = _itm.cojBGPlanAMT,
                        cojBGAllotAMT = _itm.cojBGAllotAMT,
                        cojBGApproveAMT = _itm.cojBGApproveAMT,
                        cojBGTransferAMT = _itm.cojBGTransferAMT,
                        remark = _itm.remark
                        // startDate = "",
                        // endDate = ""
                    };

                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";

                    _context.cojIntegrations.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojIntegrations.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojIntegration = await _context.cojIntegrations.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegration.Count != 0) {
                    return Ok (_cojIntegration);
                }

                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // PUT: api/cojIntegration/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojIntegration item) {

            try {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojIntegrations.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                var _items = await _context.cojIntegrations.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                foreach (var _itm in _items) {
                    var _item = await _context.cojIntegrations.FindAsync (_itm.id);
                    _item.endDate = DateTime.Now.ToString (_culture);
                    _context.Entry (_item).State = EntityState.Modified;
                    await _context.SaveChangesAsync ();
                }

                //Add new
                cojIntegration _itemNew = new cojIntegration {
                    idRef = item.idRef,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojWorkActivityItemId = item.cojWorkActivityItemId,
                    cojBudgetType = item.cojBudgetType,
                    cojAgencyId = item.cojAgencyId,
                    cojBGPlanAMT = item.cojBGPlanAMT,
                    cojBGAllotAMT = item.cojBGAllotAMT,
                    cojBGApproveAMT = item.cojBGApproveAMT,
                    cojBGTransferAMT = item.cojBGTransferAMT,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojIntegrations.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // Delete : api/cojIntegration/2 
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {

            var _item = await _context.cojIntegrations.FindAsync (id);

            try {
                if (_item == null) {
                    return NoContent ();
                }

                //update endDate
                _item.endDate = DateTime.Now.ToString (_culture);
                _context.Entry (_item).State = EntityState.Modified;
                await _context.SaveChangesAsync ();

                return Ok ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

    }
}