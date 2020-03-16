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
    public class cojRevenuesController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRevenuesController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojRevenues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRevenue>>> GetAllItem () {


            try
            {
                var _cojRevenue = await _context.cojRevenues.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojRevenue.Count != 0)
                {
                    return Ok(_cojRevenue);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojRevenues/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRevenue>>> GetAll () {
            
            try
            {
                var _cojRevenue = await _context.cojRevenues.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojRevenue.Count != 0)
                {
                    return Ok(_cojRevenue);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRevenues/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRevenue>>> GetHistory (long id) {
            
            try
            {
                var _cojRevenue = await _context.cojRevenues.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojRevenue.Count != 0)
                {
                    return Ok(_cojRevenue);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRevenues/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRevenue>>> searchName(string term)
        {
            
            try
            {
                var _cojRevenue = await _context.cojRevenues.Where(x => x.cojDocNo.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojRevenue.Count != 0)
                {
                    return Ok(_cojRevenue);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojRevenues/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojRevenue>> GetItem (long id) {

            try
            {
                var cojRevenue = await _context.cojRevenues.FindAsync (id);
                
                if (cojRevenue == null) {

                    return NoContent ();

                }

                    return Ok(cojRevenue);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojRevenues
        [HttpPost]
        public async Task<ActionResult<cojRevenue>> CreateItem (cojRevenue newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojRevenues.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojRevenues.FindAsync (newItem.id);
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

        // PUT: api/cojRevenues/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojRevenue item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojRevenues.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture); 
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojRevenues.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojRevenues.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojRevenue _itemNew = new cojRevenue {
                    idRef = item.idRef,
                    itemSort = item.itemSort,
                    cojDocNo = item.cojDocNo,
                    cojDocDate = item.cojDocDate,
                    cojRevenueFromDate = item.cojRevenueFromDate,
                    cojRevenueToDate = item.cojRevenueToDate,
                    cojRevenueAMT = item.cojRevenueAMT,
                    cojRevenueOperationAMT = item.cojRevenueOperationAMT,
                    cojRevenueInvestAMT = item.cojRevenueInvestAMT,
                    cojFund = item.cojFund,
                    cojPeriod = item.cojPeriod,
                    cojRevenueAllotNo = item.cojRevenueAllotNo,
                    cojRevenueAllotAMT = item.cojRevenueAllotAMT,
                    cojRevenueAllotOperation = item.cojRevenueAllotOperation,
                    cojRevenueAllotInvest = item.cojRevenueAllotInvest,
                    cojRevenueBalanceOperation = item.cojRevenueBalanceOperation,
                    cojRevenueBalanceInvest = item.cojRevenueBalanceInvest,
                    cojRevenueBalanceAMT = item.cojRevenueBalanceAMT,
                    cojRevenueNetOperation = item.cojRevenueNetOperation,
                    cojRevenueNetInvest = item.cojRevenueNetInvest,
                    cojRevenueNetAMT = item.cojRevenueNetAMT
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojRevenues.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojRevenues/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojRevenues.FindAsync (id);

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