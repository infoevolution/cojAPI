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
    public class cojRevenueAllotsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRevenueAllotsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojRevenueAllots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRevenueAllot>>> GetAllItem () {


            try
            {
                var _cojRevenueAllot = await _context.cojRevenueAllots.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojRevenueAllot.Count != 0)
                {
                    return Ok(_cojRevenueAllot);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojRevenueAllots/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRevenueAllot>>> GetAll () {
            
            try
            {
                var _cojRevenueAllot = await _context.cojRevenueAllots.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojRevenueAllot.Count != 0)
                {
                    return Ok(_cojRevenueAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRevenueAllots/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRevenueAllot>>> GetHistory (long id) {
            
            try
            {
                var _cojRevenueAllot = await _context.cojRevenueAllots.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojRevenueAllot.Count != 0)
                {
                    return Ok(_cojRevenueAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // // GET: api/cojRevenueAllots/searchName
        // [Route("[action]/{term}")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<cojRevenueAllot>>> searchName(string term)
        // {
            
        //     try
        //     {
        //         var _cojRevenueAllot = await _context.cojRevenueAllots.Where(x => x.cojDocNo.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

        //         if(_cojRevenueAllot.Count != 0)
        //         {
        //             return Ok(_cojRevenueAllot);
        //         }
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
            
        // }

        // GET: api/cojRevenueAllots/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojRevenueAllot>> GetItem (long id) {

            try
            {
                var cojRevenueAllot = await _context.cojRevenueAllots.FindAsync (id);
                
                if (cojRevenueAllot == null) {

                    return NoContent ();

                }

                    return Ok(cojRevenueAllot);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojRevenueAllots
        [HttpPost]
        public async Task<ActionResult<cojRevenueAllot>> CreateItem (cojRevenueAllot newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojRevenueAllots.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojRevenueAllots.FindAsync (newItem.id);
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

        // PUT: api/cojRevenueAllots/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojRevenueAllot item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojRevenueAllots.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture); 
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojRevenueAllots.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojRevenueAllots.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojRevenueAllot _itemNew = new cojRevenueAllot {
                    idRef = item.idRef,
                    cojFund = item.cojFund,
                    cojPeriod = item.cojPeriod,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBudgetType = item.cojBudgetType,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojBGWorkplanActivityId = item.cojBGWorkplanActivityId,
                    cojAllotNo = item.cojAllotNo,
                    cojAllot = item.cojAllot
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojRevenueAllots.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojRevenueAllots/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojRevenueAllots.FindAsync (id);

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