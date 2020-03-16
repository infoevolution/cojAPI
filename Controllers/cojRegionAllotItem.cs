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
    public class cojRegionAllotItemsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRegionAllotItemsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojRegionAllotItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionAllotItem>>> GetAllItem () {

            try {
                var _cojRegionAllotItem = await _context.cojRegionAllotItems.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojRegionAllotItem.Count != 0) {
                    return Ok (_cojRegionAllotItem);
                }
                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        //GET: api/cojRegionAllotItems/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionAllotItem>>> GetAll () {

            try {
                var _cojRegionAllotItem = await _context.cojRegionAllotItems.OrderBy (a => a.idRef).ToListAsync ();

                if (_cojRegionAllotItem.Count != 0) {
                    return Ok (_cojRegionAllotItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojRegionAllotItems/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionAllotItem>>> GetHistory (long id) {

            try {
                var _cojRegionAllotItem = await _context.cojRegionAllotItems.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if (_cojRegionAllotItem.Count != 0) {
                    return Ok (_cojRegionAllotItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojRegionAllotItems/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojRegionAllotItem>> GetItem (long id) {

            try {
                var _cojRegionAllotItem = await _context.cojRegionAllotItems.FindAsync (id);

                if (_cojRegionAllotItem == null) {

                    return NoContent ();

                }

                return Ok (_cojRegionAllotItem);

            } catch (Exception ex) {

                return BadRequest (ex.Message);
            }

        }

        // POST: api/cojRegionAllotItems
        [HttpPost]
        public async Task<ActionResult<cojRegionAllotItem>> CreateItem (cojRegionAllotItem newItem) {

            try {
                //check duplicate item id, code, name
                if (newItem.id != 0) {
                    return NoContent ();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojRegionAllotItems.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojRegionAllotItems.FindAsync (newItem.id);
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

        [Route ("[action]")] // POST MORE Row: api/cojRegionAllotItems/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojRegionAllotItem>>> UploadItem (cojRegionAllotItem[] newItems) {

            try {
                foreach (var _itm in newItems) {

                    cojRegionAllotItem newItem = new cojRegionAllotItem {
                        idRef = 0,
                        cojRegionAllotId = _itm.cojRegionAllotId,
                        cojAgencyId = _itm.cojAgencyId,
                        itemSort = _itm.itemSort,
                        name = _itm.name,
                        cojRegionAllotUnit = _itm.cojRegionAllotUnit,
                        cojRegionAllotUnitName = _itm.cojRegionAllotUnitName,
                        cojRegionAllotUnitPrice = _itm.cojRegionAllotUnitPrice,
                        cojRegionAllotAMT = _itm.cojRegionAllotAMT
                        // startDate = "",
                        // endDate = ""
                    };
                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";

                    _context.cojRegionAllotItems.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojRegionAllotItems.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojRegionAllotItem = await _context.cojRegionAllotItems.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojRegionAllotItem.Count != 0) {
                    return Ok (_cojRegionAllotItem);
                }

                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // PUT: api/cojRegionAllotItems/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojRegionAllotItem item) {

            try {
                if (id != item.id) {
                    return NoContent ();
                }

                // var _items = await _context.cojRegionAllotItems.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojRegionAllotItems.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojRegionAllotItem _itemNew = new cojRegionAllotItem {
                    idRef = item.idRef,
                    cojRegionAllotId = item.cojRegionAllotId,
                    cojAgencyId = item.cojAgencyId,
                    itemSort = item.itemSort,
                    name = item.name,
                    cojRegionAllotUnit = item.cojRegionAllotUnit,
                    cojRegionAllotUnitName = item.cojRegionAllotUnitName,
                    cojRegionAllotUnitPrice = item.cojRegionAllotUnitPrice,
                    cojRegionAllotAMT = item.cojRegionAllotAMT
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojRegionAllotItems.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // Delete : api/cojRegionAllotItems/2 
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {

            var _item = await _context.cojRegionAllotItems.FindAsync (id);

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