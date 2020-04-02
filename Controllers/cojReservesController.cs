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
    public class cojReservesController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojReservesController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojReserves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojReserve>>> GetAllItem () {


            try
            {
                var _cojReserve = await _context.cojReserves.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojReserve.Count != 0)
                {
                    return Ok(_cojReserve);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojReserves/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojReserve>>> GetAll () {
            
            try
            {
                var _cojReserve = await _context.cojReserves.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojReserve.Count != 0)
                {
                    return Ok(_cojReserve);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojReserves/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojReserve>>> GetHistory (long id) {
            
            try
            {
                var _cojReserve = await _context.cojReserves.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojReserve.Count != 0)
                {
                    return Ok(_cojReserve);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojReserves/AllotSummary
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojReserveAllotSummary>>> AllotSummary (long fy) {
            
            try
            {
                var _ret = await _context.cojReserveAllotSummary.FromSql ($"select * from fvw_cojFYcojReserveSummary({fy})").ToListAsync ();

                if(_ret.Count != 0)
                {
                    return Ok(_ret);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // // GET: api/cojReserves/searchName
        // [Route("[action]/{term}")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<cojReserve>>> searchName(string term)
        // {
            
        //     try
        //     {
        //         var _cojReserve = await _context.cojReserves.Where(x => x.cojDocNo.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

        //         if(_cojReserve.Count != 0)
        //         {
        //             return Ok(_cojReserve);
        //         }
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
            
        // }

        // GET: api/cojReserves/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojReserve>> GetItem (long id) {

            try
            {
                var cojReserve = await _context.cojReserves.FindAsync (id);
                
                if (cojReserve == null) {

                    return NoContent ();

                }

                    return Ok(cojReserve);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojReserves
        [HttpPost]
        public async Task<ActionResult<cojReserve>> CreateItem (cojReserve newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojReserves.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojReserves.FindAsync (newItem.id);
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

        // PUT: api/cojReserves/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojReserve item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojReserves.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture); 
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojReserves.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojReserves.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojReserve _itemNew = new cojReserve {
                    idRef = item.idRef,
                    itemSort = item.itemSort,
                    cojAgencyId = item.cojAgencyId,
                    cojPeriod = item.cojPeriod,
                    cojFund = item.cojFund,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojBGWorkplanName = item.cojBGWorkplanName,
                    cojStgPlanId = item.cojStgPlanId,
                    cojStgId = item.cojStgId,
                    cojReserveNo = item.cojReserveNo,
                    cojReserveDate = item.cojReserveDate,
                    cojReserveDocNo = item.cojReserveDocNo,
                    cojReserveSumA = item.cojReserveSumA,
                    cojReserveSumB = item.cojReserveSumB,
                    cojReserveSumC = item.cojReserveSumC,
                    cojReserveSumAMT = item.cojReserveSumAMT,
                    cojReserveFeeB = item.cojReserveFeeB,
                    cojReserveFeeC = item.cojReserveFeeC,
                    cojReserveFeeAMT = item.cojReserveFeeAMT,
                    cojReserveTransferDocNo = item.cojReserveTransferDocNo,
                    responsibilityAgency = item.responsibilityAgency,
                    procumentAgency = item.procumentAgency,
	                disbursementAgency = item.disbursementAgency,
                    cojReserveType = item.cojReserveType,
                    cojReserveStatus = item.cojReserveStatus,
                    cojBGPlanAllotId = item.cojBGPlanAllotId,
                    cojBGTransferRequestId = item.cojBGTransferRequestId,
                    cojBGTransferId = item.cojBGTransferId,
                    cojWorkActivityItemId = item.cojWorkActivityItemId,
                    cojRequestItemDetail = item.cojRequestItemDetail,
                    remark=item.remark,
                    cojCarryOverItemId=item.cojCarryOverItemId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojReserves.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojReserves/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojReserves.FindAsync (id);

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