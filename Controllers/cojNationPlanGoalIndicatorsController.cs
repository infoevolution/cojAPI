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
    public class cojNationPlanGoalIndicatorsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojNationPlanGoalIndicatorsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojNationPlanGoalIndicators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoalIndicator>>> GetAllItem () {


            try
            {
                var _cojNationPlanGoalIndicator = await _context.cojNationPlanGoalIndicators.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojNationPlanGoalIndicator.Count != 0)
                {
                    return Ok(_cojNationPlanGoalIndicator);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlanGoalIndicators/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoalIndicator>>> GetAll () {
            
            try
            {
                var _cojNationPlanGoalIndicator = await _context.cojNationPlanGoalIndicators.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojNationPlanGoalIndicator.Count != 0)
                {
                    return Ok(_cojNationPlanGoalIndicator);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlanGoalIndicators/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoalIndicator>>> GetHistory (long id) {
            
            try
            {
                var _cojNationPlanGoalIndicator = await _context.cojNationPlanGoalIndicators.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojNationPlanGoalIndicator.Count != 0)
                {
                    return Ok(_cojNationPlanGoalIndicator);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlanGoalIndicators/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoalIndicator>>> searchName(string term)
        {
            
            try
            {
                var _cojNationPlanGoalIndicator = await _context.cojNationPlanGoalIndicators.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojNationPlanGoalIndicator.Count != 0)
                {
                    return Ok(_cojNationPlanGoalIndicator);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlanGoalIndicators/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojNationPlanGoalIndicator>> GetItem (long id) {

            try
            {
                var cojNationPlanGoalIndicator = await _context.cojNationPlanGoalIndicators.FindAsync (id);
                
                if (cojNationPlanGoalIndicator == null) {

                    return NoContent ();

                }

                    return Ok(cojNationPlanGoalIndicator);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojNationPlanGoalIndicators
        [HttpPost]
        public async Task<ActionResult<cojNationPlanGoalIndicator>> CreateItem (cojNationPlanGoalIndicator newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojNationPlanGoalIndicators.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojNationPlanGoalIndicators.FindAsync (newItem.id);
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

        // PUT: api/v1/cojNationPlanGoalIndicators/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojNationPlanGoalIndicator item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojNationPlanGoalIndicators.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojNationPlanGoalIndicators.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojNationPlanGoalIndicators.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojNationPlanGoalIndicator _itemNew = new cojNationPlanGoalIndicator {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojNationPlanId = item.cojNationPlanId,
                    cojNationPlanStgId = item.cojNationPlanStgId,
                    cojNationPlanGoalId = item.cojNationPlanGoalId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojNationPlanGoalIndicators.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojNationPlanGoalIndicators/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojNationPlanGoalIndicators.FindAsync (id);

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