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
    public class cojBGTransfersController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGTransfersController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGTransfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransfer>>> GetAllItem () {


            try
            {
                var _cojBGTransfer = await _context.cojBGTransfers.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGTransfer.Count != 0)
                {
                    return Ok(_cojBGTransfer);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGTransfers/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransfer>>> GetAll () {
            
            try
            {
                var _cojBGTransfer = await _context.cojBGTransfers.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGTransfer.Count != 0)
                {
                    return Ok(_cojBGTransfer);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGTransfers/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGTransfer>>> GetHistory (long id) {
            
            try
            {
                var _cojBGTransfer = await _context.cojBGTransfers.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGTransfer.Count != 0)
                {
                    return Ok(_cojBGTransfer);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // // GET: api/cojBGTransfers/searchName
        // [Route("[action]/{term}")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<cojBGTransfer>>> searchName(string term)
        // {
            
        //     try
        //     {
        //         var _cojBGTransfer = await _context.cojBGTransfers.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

        //         if(_cojBGTransfer.Count != 0)
        //         {
        //             return Ok(_cojBGTransfer);
        //         }
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
            
        // }

        // GET: api/cojBGTransfers/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGTransfer>> GetItem (long id) {

            try
            {
                var cojBGTransfer = await _context.cojBGTransfers.FindAsync (id);
                
                if (cojBGTransfer == null) {

                    return NoContent ();

                }

                    return Ok(cojBGTransfer);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGTransfers
        [HttpPost]
        public async Task<ActionResult<cojBGTransfer>> CreateItem (cojBGTransfer newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGTransfers.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGTransfers.FindAsync (newItem.id);
                // _item.startDate = DateTime.Now.ToString (_culture);                
                // _item.endDate = "31/12/9999 00:00:00";
                // _item.idRef = newItem.id;
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Route("[action]")]  // POST MORE Row: api/cojBGTransfers/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGTransfer>>> UploadItem (cojBGTransfer[] newItems) {
            
            try
            {
                foreach (var _itm in newItems) {

                    cojBGTransfer newItem = new cojBGTransfer {
                    idRef = 0,
                     cojBGTransferFY = _itm.cojBGTransferFY,
                    cojBGTransferNO = _itm.cojBGTransferNO,
                    cojBGTransferDataDate = _itm.cojBGTransferDataDate,
                    cojBGTransferPostDate = _itm.cojBGTransferPostDate,
                    cojBGTransferPeriod = _itm.cojBGTransferPeriod,
                    cojBGTransferA = _itm.cojBGTransferA,
                    cojBGTransferB = _itm.cojBGTransferB,
                    cojBGTransferC = _itm.cojBGTransferC,
                    cojBGTransferAMT = _itm.cojBGTransferAMT,
                    cojBGTransferType = _itm.cojBGTransferType,
                    startDate = "",
                    endDate = ""
                    };
                    
                    _context.cojBGTransfers.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojBGTransfers.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);                
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojBGTransfer = await _context.cojBGTransfers.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGTransfer.Count != 0)
                {
                    return Ok(_cojBGTransfer);
                }

                return NoContent();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojBGTransfers/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGTransfer item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanTransferAllots.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGTransfers.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGTransfers.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGTransfer _itemNew = new cojBGTransfer {
                    idRef = item.idRef,
                    cojBGTransferFY = item.cojBGTransferFY,
                    cojBGTransferNO = item.cojBGTransferNO,
                    cojBGTransferDataDate = item.cojBGTransferDataDate,
                    cojBGTransferPostDate = item.cojBGTransferPostDate,
                    cojBGTransferPeriod = item.cojBGTransferPeriod,
                    cojBGTransferA = item.cojBGTransferA,
                    cojBGTransferB = item.cojBGTransferB,
                    cojBGTransferC = item.cojBGTransferC,
                    cojBGTransferAMT = item.cojBGTransferAMT,
                    cojBGTransferType = item.cojBGTransferType
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGTransfers.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGTransfers/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGTransfers.FindAsync (id);

            try
            {
                if (_item == null) {
                    return NoContent ();
                }

                //update endDate
                _item.endDate = DateTime.Now.ToString (_culture);
                _context.Entry (_item).State = EntityState.Modified;
                await _context.SaveChangesAsync ();

                return Ok ();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}