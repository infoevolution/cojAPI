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
    public class cojBGTransferDocItemsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGTransferDocItemsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGTransferDocItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransferDocItem>>> GetAllItem () {

            try {
                var _cojBGTransferDocItem = await _context.cojBGTransferDocItems.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojBGTransferDocItem.Count != 0) {
                    return Ok (_cojBGTransferDocItem);
                }
                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        //GET: api/cojBGTransferDocItems/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransferDocItem>>> GetAll () {

            try {
                var _cojBGTransferDocItem = await _context.cojBGTransferDocItems.OrderBy (a => a.idRef).ToListAsync ();

                if (_cojBGTransferDocItem.Count != 0) {
                    return Ok (_cojBGTransferDocItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojBGTransferDocItems/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransferDocItem>>> GetHistory (long id) {

            try {
                var _cojBGTransferDocItem = await _context.cojBGTransferDocItems.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if (_cojBGTransferDocItem.Count != 0) {
                    return Ok (_cojBGTransferDocItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojBGTransferDocItems/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGTransferDocItem>> GetItem (long id) {

            try {
                var _cojBGTransferDocItem = await _context.cojBGTransferDocItems.FindAsync (id);

                if (_cojBGTransferDocItem == null) {

                    return NoContent ();

                }

                return Ok (_cojBGTransferDocItem);

            } catch (Exception ex) {

                return BadRequest (ex.Message);
            }

        }

        // POST: api/cojBGTransferDocItems
        [HttpPost]
        public async Task<ActionResult<cojBGTransferDocItem>> CreateItem (cojBGTransferDocItem newItem) {

            try {
                //check duplicate item id, code, name
                if (newItem.id != 0) {
                    return NoContent ();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGTransferDocItems.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGTransferDocItems.FindAsync (newItem.id);
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

        [Route ("[action]")] // POST MORE Row: api/cojBGTransferDocItems/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGTransferDocItem>>> UploadItem (cojBGTransferDocItem[] newItems) {

            try {
                foreach (var _itm in newItems) {

                    cojBGTransferDocItem newItem = new cojBGTransferDocItem {
                        idRef = 0,
                        cojBGTransferId = _itm.cojBGTransferId,
                        cojBGTransferDocId = _itm.cojBGTransferDocId,
                        cojBGPlanId = _itm.cojBGPlanId,
                        cojWorkplanType = _itm.cojWorkplanType,
                        cojBGWorkplanId = _itm.cojBGWorkplanId,
                        cojWorkActivityId = _itm.cojWorkActivityId,
                        cojBGTransferA = _itm.cojBGTransferA,
                        cojBGTransferB = _itm.cojBGTransferB,
                        cojBGTransferC = _itm.cojBGTransferC,
                        name = _itm.name,
                        startDate = "",
                        endDate = ""
                    };

                    _context.cojBGTransferDocItems.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojBGTransferDocItems.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojBGTransferDocItem = await _context.cojBGTransferDocItems.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojBGTransferDocItem.Count != 0) {
                    return Ok (_cojBGTransferDocItem);
                }

                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // PUT: api/cojBGTransferDocItems/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGTransferDocItem item) {

            try {
                if (id != item.id) {
                    return NoContent ();
                }

                // var _items = await _context.cojBGTransferDocItems.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGTransferDocItems.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGTransferDocItem _itemNew = new cojBGTransferDocItem {
                    idRef = item.idRef,
                    cojBGTransferId = item.cojBGTransferId,
                    cojBGTransferDocId = item.cojBGTransferDocId,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanType = item.cojWorkplanType,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojBGTransferA = item.cojBGTransferA,
                    cojBGTransferB = item.cojBGTransferB,
                    cojBGTransferC = item.cojBGTransferC,
                    name = item.name
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGTransferDocItems.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // Delete : api/cojBGTransferDocItems/2 
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {

            var _item = await _context.cojBGTransferDocItems.FindAsync (id);

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