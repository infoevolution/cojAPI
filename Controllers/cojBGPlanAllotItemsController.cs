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
    public class cojBGPlanAllotItemsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanAllotItemsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanAllotItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllotItem>>> GetAllItem () {


            try
            {
                var _cojBGPlanAllotItem = await _context.cojBGPlanAllotItems.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanAllotItem.Count != 0)
                {
                    return Ok(_cojBGPlanAllotItem);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanAllotItem/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllotItem>>> GetAll () {
            
            try
            {
                var _cojBGPlanAllotItem = await _context.cojBGPlanAllotItems.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanAllotItem.Count != 0)
                {
                    return Ok(_cojBGPlanAllotItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanAllotItems/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllotItem>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanAllotItem = await _context.cojBGPlanAllotItems.Where (x => x.idRef == id && x.endDate == "31/12/9999 00:00:00").OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanAllotItem.Count != 0)
                {
                    return Ok(_cojBGPlanAllotItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanAllotItems/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllotItem>>> Allot (long id) {
            
            try
            {
                var _cojBGPlanAllotItem = await _context.cojBGPlanAllotItems.Where (x => x.cojBGPlanAllotId == id && x.endDate == "31/12/9999 00:00:00").OrderByDescending (a => a.idRef).ToListAsync ();

                if(_cojBGPlanAllotItem.Count != 0)
                {
                    return Ok(_cojBGPlanAllotItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // // GET: api/cojBGPlanAllots/searchName
        // [Route("[action]/{term}")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<cojBGPlanAllot>>> searchName(string term)
        // {
            
        //     try
        //     {
        //         var _cojBGPlanAllot = await _context.cojBGPlanAllots.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

        //         if(_cojBGPlanAllot.Count != 0)
        //         {
        //             return Ok(_cojBGPlanAllot);
        //         }
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
            
        // }

        // GET: api/cojBGPlanAllotItems/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanAllotItem>> GetItem (long id) {

            try
            {
                var cojBGPlanAllotItem = await _context.cojBGPlanAllotItems.FindAsync (id);
                
                if (cojBGPlanAllotItem == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanAllotItem);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        // POST: api/cojBGPlanAllotItem
        [HttpPost]
        public async Task<ActionResult<cojBGPlanAllotItem>> CreateItem (cojBGPlanAllotItem newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";
                
                _context.cojBGPlanAllotItems.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojBGPlanAllotItem/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanAllotItem item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlans.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                //  var _items = await _context.cojBGPlanAllotItems.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanAllotItems.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanAllotItem _itemNew = new cojBGPlanAllotItem {
                    idRef = item.idRef,
                    cojBGPlanAllotId = item.cojBGPlanAllotId,
                    cojBGPlanAllotToAgency = item.cojBGPlanAllotToAgency,
                    itemNO = item.itemNO,
                    itemName = item.itemName,
                    itemUnit = item.itemUnit,
                    itemUnitName = item.itemUnitName,
                    itemUnitPrice = item.itemUnitPrice,
                    itemParentId = item.itemParentId,
                    itemLevel = item.itemLevel,
                    itemAllotRequestAMT = item.itemAllotRequestAMT,
                    itemAllotAMT = item.itemAllotAMT,
                    itemTransferRequestAMT = item.itemTransferRequestAMT,
                    cojBGTransferRequestId = item.cojBGTransferRequestId,
                    itemTransferAMT = item.itemTransferAMT,
                    cojBGTransferId = item.cojBGTransferId,
                    itemTypeId = item.itemTypeId,
                    flagIntegration = item.flagIntegration,
                    flagRegionReserve = item.flagRegionReserve,
                    responsibilityAgency = item.responsibilityAgency ,
                    procumentAgency = item.procumentAgency,
                    disbursementAgency = item.disbursementAgency,
                    flagAgencyReserve = item.flagAgencyReserve,
                    cojFund = item.cojFund
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanAllotItems.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanAllotItem/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanAllotItems.FindAsync (id);

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