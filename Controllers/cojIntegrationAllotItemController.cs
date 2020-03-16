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
    public class cojIntegrationAllotItemsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojIntegrationAllotItemsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojIntegrationAllotItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllotItem>>> GetAllItem () {

            try {
                var _cojIntegrationAllotItem = await _context.cojIntegrationAllotItems.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegrationAllotItem.Count != 0) {
                    return Ok (_cojIntegrationAllotItem);
                }
                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        //GET: api/cojIntegrationAllotItem/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllotItem>>> GetAll () {

            try {
                var _cojIntegrationAllotItem = await _context.cojIntegrationAllotItems.OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegrationAllotItem.Count != 0) {
                    return Ok (_cojIntegrationAllotItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojIntegrationAllotItem/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllotItem>>> GetHistory (long id) {

            try {
                var _cojIntegrationAllotItem = await _context.cojIntegrationAllotItems.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if (_cojIntegrationAllotItem.Count != 0) {
                    return Ok (_cojIntegrationAllotItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojIntegrationAllotItem/searchName
        [Route ("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllotItem>>> searchName (string term) {

            try {
                var _cojIntegrationAllotItem = await _context.cojIntegrationAllotItems.Where (x => x.name.ToLowerInvariant ().Contains (term) &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.id).ToListAsync ();

                if (_cojIntegrationAllotItem.Count != 0) {
                    return Ok (_cojIntegrationAllotItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // GET: api/cojIntegrationAllotItem/integrationAllot
        [Route ("[action]/{integrationAllotId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllotItem>>> integrationAllot (double integrationAllotId) {

            try {
                var _cojIntegrationAllotItem = await _context.cojIntegrationAllotItems.Where (x => x.cojIntegrationAllotId == integrationAllotId &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.id).ToListAsync ();

                if (_cojIntegrationAllotItem.Count != 0) {
                    return Ok (_cojIntegrationAllotItem);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // GET: api/cojIntegrationAllotItem/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojIntegrationAllotItem>> GetItem (long id) {

            try {
                var cojIntegrationAllotItem = await _context.cojIntegrationAllotItems.FindAsync (id);

                if (cojIntegrationAllotItem == null) {

                    return NoContent ();

                }

                return Ok (cojIntegrationAllotItem);

            } catch (Exception ex) {

                return BadRequest (ex.Message);
            }

        }

        // POST: api/cojIntegrationAllotItem
        [HttpPost]
        public async Task<ActionResult<cojIntegrationAllotItem>> CreateItem (cojIntegrationAllotItem newItem) {

            try {
                //check duplicate item id, code, name
                if (newItem.id != 0) {

                    return NoContent ();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojIntegrationAllotItems.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojIntegrationAllotItems.FindAsync (newItem.id);
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

        [Route ("[action]")] // POST MORE Row: api/cojIntegrationAllotItem/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojIntegrationAllotItem>>> UploadItem (cojIntegrationAllotItem[] newItems) {

            try {
                foreach (var _itm in newItems) {

                    cojIntegrationAllotItem newItem = new cojIntegrationAllotItem {
                        idRef = 0,
                        name = _itm.name,
                        itemSort = _itm.itemSort,
                        cojIntegrationId = _itm.cojIntegrationId,
                        cojIntegrationAllotId = _itm.cojIntegrationAllotId,
                        cojAgencyId = _itm.cojAgencyId,
                        cojBGTransferAMT = _itm.cojBGTransferAMT,
                        startDate = "",
                        endDate = ""
                    };

                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";

                    _context.cojIntegrationAllotItems.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojIntegrationAllotItems.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojIntegrationAllotItem = await _context.cojIntegrationAllotItems.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojIntegrationAllotItem.Count != 0) {
                    return Ok (_cojIntegrationAllotItem);
                }

                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // PUT: api/cojIntegrationAllotItem/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojIntegrationAllotItem item) {

            try {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojIntegrationAllotItems.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojIntegrationAllotItems.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojIntegrationAllotItems.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojIntegrationAllotItem _itemNew = new cojIntegrationAllotItem {
                    idRef = item.idRef,
                    name = item.name,
                    itemSort = item.itemSort,
                    cojIntegrationId = item.cojIntegrationId,
                    cojIntegrationAllotId = item.cojIntegrationAllotId,
                    cojAgencyId = item.cojAgencyId,
                    cojBGTransferAMT = item.cojBGTransferAMT
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojIntegrationAllotItems.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // Delete : api/cojIntegrationAllotItem/2 
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {

            var _item = await _context.cojIntegrationAllotItems.FindAsync (id);

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