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
    public class cojBGPlanWorkplanActivityGoalIndicatorsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplanActivityGoalIndicatorsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojBGPlanWorkplanActivityGoalIndicators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityGoalIndicator>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplanActivityGoalIndicator = await _context.cojBGPlanWorkplanActivityGoalIndicators.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplanActivityGoalIndicator.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityGoalIndicator);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBGPlanWorkplanActivityGoalIndicators/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityGoalIndicator>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplanActivityGoalIndicator = await _context.cojBGPlanWorkplanActivityGoalIndicators.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplanActivityGoalIndicator.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityGoalIndicator);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBGPlanWorkplanActivityGoalIndicators/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityGoalIndicator>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplanActivityGoalIndicator = await _context.cojBGPlanWorkplanActivityGoalIndicators.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplanActivityGoalIndicator.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityGoalIndicator);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBGPlanWorkplanActivityGoalIndicators/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityGoalIndicator>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanWorkplanActivityGoalIndicator = await _context.cojBGPlanWorkplanActivityGoalIndicators.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanWorkplanActivityGoalIndicator.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityGoalIndicator);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBGPlanWorkplanActivityGoalIndicators/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplanActivityGoalIndicator>> GetItem (long id) {

            try
            {
                var cojBGPlanWorkplanActivityGoalIndicator = await _context.cojBGPlanWorkplanActivityGoalIndicators.FindAsync (id);
                
                if (cojBGPlanWorkplanActivityGoalIndicator == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanWorkplanActivityGoalIndicator);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojBGPlanWorkplanActivityGoalIndicators
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplanActivityGoalIndicator>> CreateItem (cojBGPlanWorkplanActivityGoalIndicator newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanWorkplanActivityGoalIndicators.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplanActivityGoalIndicators.FindAsync (newItem.id);
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

        // PUT: api/v1/cojBGPlanWorkplanActivityGoalIndicators/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplanActivityGoalIndicator item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBGPlanWorkplanActivityGoalIndicators.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();


                // var _items = await _context.cojBGPlanWorkplanActivityGoalIndicators.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplanActivityGoalIndicators.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanWorkplanActivityGoalIndicator _itemNew = new cojBGPlanWorkplanActivityGoalIndicator {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojBGWorkplanActivityId = item.cojBGWorkplanActivityId,
                    //cojBGPlanWorkplanActivityGoalId = item.cojBGPlanWorkplanActivityGoalId,
                    cojBGWorkplanActivityGoalId = item.cojBGWorkplanActivityGoalId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanWorkplanActivityGoalIndicators.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojBGPlanWorkplanActivityGoalIndicators/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplanActivityGoalIndicators.FindAsync (id);

            try
            {
                if (_item == null) {
                    return NoContent ();
                }

                //update dateEnd
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