using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using cojApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cojApi.Controllers {
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class cojRegionAllotsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRegionAllotsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojRegionAllots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionAllot>>> GetAllItem () {

            try {
                var _cojRegionAllot = await _context.cojRegionAllots.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojRegionAllot.Count != 0) {
                    return Ok (_cojRegionAllot);
                }
                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        //GET: api/cojRegionAllots/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionAllot>>> GetAll () {

            try {
                var _cojRegionAllot = await _context.cojRegionAllots.OrderBy (a => a.idRef).ToListAsync ();

                if (_cojRegionAllot.Count != 0) {
                    return Ok (_cojRegionAllot);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojRegionAllots/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionAllot>>> GetHistory (long id) {

            try {
                var _cojRegionAllot = await _context.cojRegionAllots.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if (_cojRegionAllot.Count != 0) {
                    return Ok (_cojRegionAllot);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojRegionAllots/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojRegionAllot>> GetItem (long id) {

            try {
                var _cojRegionAllot = await _context.cojRegionAllots.FindAsync (id);

                if (_cojRegionAllot == null) {

                    return NoContent ();

                }

                return Ok (_cojRegionAllot);

            } catch (Exception ex) {

                return BadRequest (ex.Message);
            }

        }

        // POST: api/cojRegionAllots
        [HttpPost]
        public async Task<ActionResult<cojRegionAllot>> CreateItem (cojRegionAllot newItem) {

            try {
                //check duplicate item id, code, name
                if (newItem.id != 0) {
                    return NoContent ();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojRegionAllots.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojRegionAllots.FindAsync (newItem.id);
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

        [Route ("[action]")] // POST MORE Row: api/cojRegionAllots/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojRegionAllot>>> UploadItem (cojRegionAllot[] newItems) {

            try {
                foreach (var _itm in newItems) {

                    cojRegionAllot newItem = new cojRegionAllot {
                        idRef = 0,
                        cojAgencyType = _itm.cojAgencyType,
                        cojAgencyId = _itm.cojAgencyId,
                        cojBGPlanId = _itm.cojBGPlanId,
                        cojWorkplanTypeId = _itm.cojWorkplanTypeId,
                        cojBGWorkplanId = _itm.cojBGWorkplanId,
                        cojWorkActivityId = _itm.cojWorkActivityId,
                        cojBudgetType = _itm.cojBudgetType,
                        cojWorkActivityItemId = _itm.cojWorkActivityItemId,
                        itemSort = _itm.itemSort,
                        name = _itm.name,
                        cojRegionAllotDate = _itm.cojRegionAllotDate
                        // startDate = "",
                        // endDate = ""
                    };
                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";

                    _context.cojRegionAllots.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojRegionAllots.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojRegionAllot = await _context.cojRegionAllots.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojRegionAllot.Count != 0) {
                    return Ok (_cojRegionAllot);
                }

                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // PUT: api/cojRegionAllots/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojRegionAllot item) {

            try {
                if (id != item.id) {
                    return NoContent ();
                }

                // var _items = await _context.cojRegionAllots.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojRegionAllots.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojRegionAllot _itemNew = new cojRegionAllot {
                    idRef = item.idRef,
                    cojAgencyType = item.cojAgencyType,
                    cojAgencyId = item.cojAgencyId,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojBudgetType = item.cojBudgetType,
                    cojWorkActivityItemId = item.cojWorkActivityItemId,
                    itemSort = item.itemSort,
                    name = item.name,
                    cojRegionAllotDate = item.cojRegionAllotDate
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojRegionAllots.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // Delete : api/cojRegionAllots/2 
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {

            var _item = await _context.cojRegionAllots.FindAsync (id);

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