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
    public class cojBGPlanWorkplanActivitySubsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplanActivitySubsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanWorkplanActivitySub
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivitySub>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplanActivitySub = await _context.cojBGPlanWorkplanActivitySubs.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplanActivitySub.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivitySub);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanWorkplanActivitySub/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivitySub>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplanActivitySub = await _context.cojBGPlanWorkplanActivitySubs.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplanActivitySub.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivitySub);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivitySub/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivitySub>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplanActivitySub = await _context.cojBGPlanWorkplanActivitySubs.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplanActivitySub.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivitySub);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojBGPlanWorkplanActivitySub/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplanActivitySub>> GetItem (long id) {

            try
            {
                var cojBGPlanWorkplanActivitySub = await _context.cojBGPlanWorkplanActivitySubs.FindAsync (id);
                
                if (cojBGPlanWorkplanActivitySub == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanWorkplanActivitySub);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanWorkplanActivitySub
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplanActivitySub>> CreateItem (cojBGPlanWorkplanActivitySub newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanWorkplanActivitySubs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplanActivitySubs.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanWorkplanActivitySub/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplanActivitySub item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanWorkplanActivitySubs.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanWorkplanActivitySubs.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplanActivitySubs.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanWorkplanActivitySub _itemNew = new cojBGPlanWorkplanActivitySub {
                    idRef = item.idRef,
                    cojBGPlanId = item.cojBGPlanId,
                    cojBGPlanWorkplanId = item.cojBGPlanWorkplanId,
                    cojBGWorkplanActivityId = item.cojBGWorkplanActivityId,
                    cojBGWorkplanActivitySubCode = item.cojBGWorkplanActivitySubCode,
                    cojBGWorkplanActivitySubName = item.cojBGWorkplanActivitySubName,                    
                    quantityUnit = item.quantityUnit,
                    quantityUnitName = item.quantityUnitName,
                    periodStart = item.periodStart,
                    periodEnd = item.periodEnd,
                    budgetTypeId = item.budgetTypeId,
                    budgetAmount = item.budgetAmount,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanWorkplanActivitySubs.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanWorkplanActivitySub/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplanActivitySubs.FindAsync (id);

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