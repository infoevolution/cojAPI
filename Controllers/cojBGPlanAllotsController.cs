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
    public class cojBGPlanAllotsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanAllotsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanAllots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllot>>> GetAllItem () {


            try
            {
                var _cojBGPlanAllot = await _context.cojBGPlanAllots.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanAllot.Count != 0)
                {
                    return Ok(_cojBGPlanAllot);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanAllot/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllot>>> GetAll () {
            
            try
            {
                var _cojBGPlanAllot = await _context.cojBGPlanAllots.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanAllot.Count != 0)
                {
                    return Ok(_cojBGPlanAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanAllots/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllot>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanAllot = await _context.cojBGPlanAllots.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanAllot.Count != 0)
                {
                    return Ok(_cojBGPlanAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanAllots/fy
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanAllot>>> fy (int fy) {
            
            try
            {
                var _cojBGPlanAllot = await _context.cojBGPlanAllots.Where (x => x.allotFy == fy).OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanAllot.Count != 0)
                {
                    return Ok(_cojBGPlanAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanAllots/FYAllotWorkplan
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojFYAllotWorkplan>>> FYAllotWorkplan (int fy) {

            try {
                var _ret = await _context.vwCojFYAllotWorkplans.Where(a => a.fy==fy).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojBGPlanAllots/FYAllotWorkActivity
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojRegionReserveFYWorkActivity>>> FYAllotWorkActivity (int fy) {

            try {
                var _ret = await _context.vwCojRegionReserveFYWorkActivitys.Where(a => a.fy==fy).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojBGPlanAllots/FYAllotWorkActivityBudgetType
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojFYAllotWorkplanActivityBudgetType>>> FYAllotWorkActivityBudgetType (int fy) {

            try {
                var _ret = await _context.vwCojFYAllotWorkplanActivityBudgetTypes.Where(a => a.fy==fy).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojBGPlanAllots/FYAllotWorkActivityBudgetTypeAllot
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojFYAllotWorkplanActivityBudgetTypeAllot>>> FYAllotWorkActivityBudgetTypeAllot (int fy) {

            try {
                var _ret = await _context.vwCojFYAllotWorkplanActivityBudgetTypeAllots.Where(a => a.allotFy==fy).OrderBy(a=>a.cojWorkplanTypeId | a.cojBGWorkplanId | a.cojWorkActivityId | a.cojBudgetType | a.cojBGPlanAllotNO).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
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

        // GET: api/cojBGPlanAllots/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanAllot>> GetItem (long id) {

            try
            {
                var cojBGPlanAllot = await _context.cojBGPlanAllots.Where(x => x.endDate == "31/12/9999 00:00:00" && x.idRef==id).FirstOrDefaultAsync();
                
                if (cojBGPlanAllot == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanAllot);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanAllot
        [HttpPost]
        public async Task<ActionResult<cojBGPlanAllot>> CreateItem (cojBGPlanAllot newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";
                
                 _context.cojBGPlanAllots.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;
                
                // var _id = newItem.id;
                // _context.Entry(newItem).State = EntityState.Detached;
                
                // //initial new item
                // var _item = await _context.cojBGPlanAllots.FindAsync (_id);
                return CreatedAtAction (nameof (GetItem), new { id = newItem.id  }, newItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojBGPlanAllot/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanAllot item) {
            
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

                //  var _items = await _context.cojBGPlanAllots.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanAllots.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanAllot _itemNew = new cojBGPlanAllot {
                    idRef = item.idRef,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojFund = item.cojFund,
                    cojBudgetType = item.cojBudgetType,
                    cojBGPlanAllotAgency = item.cojBGPlanAllotAgency,
                    cojBGPlanAllotNO = item.cojBGPlanAllotNO,
                    cojBGPlanAllotDate = item.cojBGPlanAllotDate,
                    cojAgencyAllotDocNO = item.cojAgencyAllotDocNO,
                    cojAgencyAllotDocDate = item.cojAgencyAllotDocDate,
                    flagAllotWithTransfer = item.flagAllotWithTransfer,
                    flagIntegration = item.flagIntegration,
                    flagRegionReserve = item.flagRegionReserve,
                    cojBGTransferType = item.cojBGTransferType,
                    cojBGTransferRequestId = item.cojBGTransferRequestId,
                    cojBGTransferId = item.cojBGTransferId,
                    allotFy = item.allotFy,
                    allotQuater = item.allotQuater,
                    allotType = item.allotType,
                    operateUser = item.operateUser,
                    operateUserName = item.operateUserName,
                    operateDate = item.operateDate,
                    auditUser = item.auditUser,
                    auditUserName = item.auditUserName,
                    auditDate = item.auditDate,
                    approveUser = item.approveUser,
                    approveUserName = item.approveUserName,
                    approveDate = item.approveDate,
                    flagAgencyReserve = item.flagAgencyReserve,
                    cojFundFY = item.cojFundFY,
                    cojCarryOverItemId = item.cojCarryOverItemId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanAllots.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanAllot/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanAllots.FindAsync (id);

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