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
    public class cojBGTransferDocsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGTransferDocsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGTransferDocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransferDoc>>> GetAllItem () {

            try {
                var _cojBGTransferDoc = await _context.cojBGTransferDocs.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojBGTransferDoc.Count != 0) {
                    return Ok (_cojBGTransferDoc);
                }
                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        //GET: api/cojBGTransferDocs/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransferDoc>>> GetAll () {

            try {
                var _cojBGTransferDoc = await _context.cojBGTransferDocs.OrderBy (a => a.idRef).ToListAsync ();

                if (_cojBGTransferDoc.Count != 0) {
                    return Ok (_cojBGTransferDoc);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojBGTransferDocs/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransferDoc>>> GetHistory (long id) {

            try {
                var _cojBGTransferDoc = await _context.cojBGTransferDocs.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if (_cojBGTransferDoc.Count != 0) {
                    return Ok (_cojBGTransferDoc);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojBGTransferDocs/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGTransferDoc>> GetItem (long id) {

            try {
                var _cojBGTransferDoc = await _context.cojBGTransferDocs.FindAsync (id);

                if (_cojBGTransferDoc == null) {

                    return NoContent ();

                }

                return Ok (_cojBGTransferDoc);

            } catch (Exception ex) {

                return BadRequest (ex.Message);
            }

        }

        // POST: api/cojBGTransferDocs
        [HttpPost]
        public async Task<ActionResult<cojBGTransferDoc>> CreateItem (cojBGTransferDoc newItem) {

            try {
                //check duplicate item id, code, name
                if (newItem.id != 0) {
                    return NoContent ();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGTransferDocs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGTransferDocs.FindAsync (newItem.id);
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

        [Route ("[action]")] // POST MORE Row: api/cojBGTransferDocs/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGTransferDoc>>> UploadItem (cojBGTransferDoc[] newItems) {

            try {
                foreach (var _itm in newItems) {

                    cojBGTransferDoc newItem = new cojBGTransferDoc {
                        idRef = 0,
                        cojBGTransferId = _itm.cojBGTransferId,
                        cojBGTransferDocDate = _itm.cojBGTransferDocDate,
                        cojBGTransferDocNO = _itm.cojBGTransferDocNO,
                        cojBGTransferAgencyId = _itm.cojBGTransferAgencyId,
                        cojBGReceiveAgencyId = _itm.cojBGReceiveAgencyId,
                        cojBGTransferA = _itm.cojBGTransferA,
                        cojBGTransferB = _itm.cojBGTransferB,
                        cojBGTransferC = _itm.cojBGTransferC,
                        cojBGTransferAMT = _itm.cojBGTransferAMT,
                        cojBGTransferType = _itm.cojBGTransferType,
                        cojBGTransferFY = _itm.cojBGTransferFY,
                        startDate = "",
                        endDate = ""
                    };

                    _context.cojBGTransferDocs.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojBGTransferDocs.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojBGTransferDoc = await _context.cojBGTransferDocs.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if (_cojBGTransferDoc.Count != 0) {
                    return Ok (_cojBGTransferDoc);
                }

                return NoContent ();

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // PUT: api/cojBGTransferDocs/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGTransferDoc item) {

            try {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanTransferAllots.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGTransferDocs.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGTransferDocs.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGTransferDoc _itemNew = new cojBGTransferDoc {
                    idRef = item.idRef,
                    cojBGTransferId = item.cojBGTransferId,
                    cojBGTransferDocDate = item.cojBGTransferDocDate,
                    cojBGTransferDocNO = item.cojBGTransferDocNO,
                    cojBGTransferAgencyId = item.cojBGTransferAgencyId,
                    cojBGReceiveAgencyId = item.cojBGReceiveAgencyId,
                    cojBGTransferA = item.cojBGTransferA,
                    cojBGTransferB = item.cojBGTransferB,
                    cojBGTransferC = item.cojBGTransferC,
                    cojBGTransferAMT = item.cojBGTransferAMT,
                    cojBGTransferType = item.cojBGTransferType,
                    cojBGTransferFY = item.cojBGTransferFY
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGTransferDocs.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

        // Delete : api/cojBGTransferDocs/2 
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {

            var _item = await _context.cojBGTransferDocs.FindAsync (id);

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