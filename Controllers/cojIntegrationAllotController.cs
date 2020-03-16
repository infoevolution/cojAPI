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
    public class cojIntegrationAllotsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojIntegrationAllotsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojIntegrationAllot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllot>>> GetAllItem () {

            try {
                var _cojIntegrationAllot = await _context.cojIntegrationAllots.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegrationAllot.Count != 0) {
                    return Ok (_cojIntegrationAllot);
                }
                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        //GET: api/cojIntegrationAllot/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllot>>> GetAll () {

            try {
                var _cojIntegrationAllot = await _context.cojIntegrationAllots.OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegrationAllot.Count != 0) {
                    return Ok (_cojIntegrationAllot);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojIntegrationAllot/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllot>>> GetHistory (long id) {

            try {
                var _cojIntegrationAllot = await _context.cojIntegrationAllots.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if (_cojIntegrationAllot.Count != 0) {
                    return Ok (_cojIntegrationAllot);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojIntegrationAllot/searchName
        [Route ("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllot>>> searchName (string term) {

            try {
                var _cojIntegrationAllot = await _context.cojIntegrationAllots.Where (x => x.name.ToLowerInvariant ().Contains (term) &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.id).ToListAsync ();

                if (_cojIntegrationAllot.Count != 0) {
                    return Ok (_cojIntegrationAllot);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // GET: api/cojIntegrationAllot/integration
        [Route ("[action]/{integrationId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllot>>> integration (double integrationId) {

            try {
                var _cojIntegrationAllot = await _context.cojIntegrationAllots.Where (x => x.cojIntegrationId == integrationId &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.id).ToListAsync ();

                if (_cojIntegrationAllot.Count != 0) {
                    return Ok (_cojIntegrationAllot);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // GET: api/cojIntegrationAllot/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojIntegrationAllot>> GetItem (long id) {

            try {
                var cojIntegrationAllot = await _context.cojIntegrationAllots.FindAsync (id);

                if (cojIntegrationAllot == null) {

                    return NoContent ();

                }

                return Ok (cojIntegrationAllot);

            } catch (Exception ex) {

                return BadRequest (ex.Message);
            }

        }

        // POST: api/cojIntegrationAllot
        [HttpPost]
        public async Task<ActionResult<cojIntegrationAllot>> CreateItem (cojIntegrationAllot newItem) {

            try {
                //check duplicate item id, code, name
                if (newItem.id != 0) {

                    return NoContent ();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojIntegrationAllots.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojIntegrationAllots.FindAsync (newItem.id);
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

        [Route ("[action]")] // POST MORE Row: api/cojIntegrationAllot/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllot>>> UploadItem (cojIntegrationAllot[] newItems) {

            try {
                foreach (var _itm in newItems) {

                    cojIntegrationAllot newItem = new cojIntegrationAllot {
                        idRef = 0,
                        name = _itm.name,
                        itemSort = _itm.itemSort,
                        cojIntegrationId = _itm.cojIntegrationId,
                        cojIntegrationAllotDate = _itm.cojIntegrationAllotDate,
                        cojBGTransferQ1 = _itm.cojBGTransferQ1,
                        cojBGTransferQ2 = _itm.cojBGTransferQ2,
                        cojBGTransferQ3 = _itm.cojBGTransferQ3,
                        cojBGTransferQ4 = _itm.cojBGTransferQ4,
                        cojBGTransferAMT = _itm.cojBGTransferAMT
                        // startDate = "",
                        // endDate = ""
                    };
                    
                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";

                    _context.cojIntegrationAllots.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojIntegrationAllots.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojIntegrationAllot = await _context.cojIntegrationAllots.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegrationAllot.Count != 0) {
                    return Ok (_cojIntegrationAllot);
                }

                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // PUT: api/cojIntegrationAllot/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojIntegrationAllot item) {

            try {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojIntegrationAllots.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojIntegrationAllots.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojIntegrationAllots.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojIntegrationAllot _itemNew = new cojIntegrationAllot {
                    idRef = item.idRef,
                    name = item.name,
                    itemSort = item.itemSort,
                    cojIntegrationId = item.cojIntegrationId,
                    cojIntegrationAllotDate = item.cojIntegrationAllotDate,
                    cojBGTransferQ1 = item.cojBGTransferQ1,
                    cojBGTransferQ2 = item.cojBGTransferQ2,
                    cojBGTransferQ3 = item.cojBGTransferQ3,
                    cojBGTransferQ4 = item.cojBGTransferQ4,
                    cojBGTransferAMT = item.cojBGTransferAMT
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojIntegrationAllots.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // Delete : api/cojIntegrationAllot/2 
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {

            var _item = await _context.cojIntegrationAllots.FindAsync (id);

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