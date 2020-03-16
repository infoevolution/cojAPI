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
    public class cojBGPlanWorkplanActivityObjectiveIndicatorsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplanActivityObjectiveIndicatorsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanWorkplanActivityObjectiveIndicators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityObjectiveIndicator>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplanActivityObjectiveIndicators = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplanActivityObjectiveIndicators.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityObjectiveIndicators);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanWorkplanActivityObjectiveIndicators/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityObjectiveIndicator>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplanActivityObjectiveIndicators = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplanActivityObjectiveIndicators.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityObjectiveIndicators);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivityObjectiveIndicators/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityObjectiveIndicator>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplanActivityObjectiveIndicators = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplanActivityObjectiveIndicators.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityObjectiveIndicators);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojBGPlanWorkplanActivityObjectiveIndicators/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityObjectiveIndicator>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanWorkplanActivityObjectiveIndicators = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojBGPlanWorkplanActivityObjectiveIndicators.Count != 0) {
                   return Ok(_cojBGPlanWorkplanActivityObjectiveIndicators);
                }

               return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivityObjectiveIndicators/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplanActivityObjectiveIndicator>> GetItem (long id) {

            try
            {
                var _cojBGPlanWorkplanActivityObjectiveIndicators = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.FindAsync (id);
                
                if (_cojBGPlanWorkplanActivityObjectiveIndicators == null) {

                    return NoContent ();

                }

                    return Ok(_cojBGPlanWorkplanActivityObjectiveIndicators);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanWorkplanActivityObjectiveIndicators
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplanActivityObjectiveIndicator>> CreateItem (cojBGPlanWorkplanActivityObjectiveIndicator newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanWorkplanActivityObjectiveIndicators.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanWorkplanActivityObjectiveIndicators/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplanActivityObjectiveIndicator item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanWorkplanActivityObjectiveIndicator _itemNew = new cojBGPlanWorkplanActivityObjectiveIndicator {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojBGWorkplanActivityId = item.cojBGWorkplanActivityId,
                    cojBGWorkplanActivityObjectiveId = item.cojBGWorkplanActivityObjectiveId,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanWorkplanActivityObjectiveIndicators.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanWorkplanActivityObjectiveIndicators/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplanActivityObjectiveIndicators.FindAsync (id);

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