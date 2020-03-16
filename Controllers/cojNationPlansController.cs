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
    public class cojNationPlansController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojNationPlansController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojNationPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlan>>> GetAllItem () {


            try
            {
                var _cojNationPlan = await _context.cojNationPlans.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojNationPlan.Count != 0)
                {
                    return Ok(_cojNationPlan);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlans/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlan>>> GetAll () {
            
            try
            {
                var _cojNationPlan = await _context.cojNationPlans.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojNationPlan.Count != 0)
                {
                    return Ok(_cojNationPlan);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlans/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlan>>> GetHistory (long id) {
            
            try
            {
                var _cojNationPlan = await _context.cojNationPlans.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojNationPlan.Count != 0)
                {
                    return Ok(_cojNationPlan);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlans/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlan>>> searchName(string term)
        {
            
            try
            {
                var _cojNationPlan = await _context.cojNationPlans.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojNationPlan.Count != 0)
                {
                    return Ok(_cojNationPlan);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlans/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojNationPlan>> GetItem (long id) {

            try
            {
                var cojNationPlan = await _context.cojNationPlans.FindAsync (id);
                
                if (cojNationPlan == null) {

                    return NoContent ();

                }

                    return Ok(cojNationPlan);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojNationPlans
        [HttpPost]
        public async Task<ActionResult<cojNationPlan>> CreateItem (cojNationPlan newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojNationPlans.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojNationPlans.FindAsync (newItem.id);
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

        // PUT: api/v1/cojNationPlans/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojNationPlan item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojNationPlans.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojNationPlans.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojNationPlans.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojNationPlan _itemNew = new cojNationPlan {
                    idRef = item.idRef,
                    name = item.name,
                    cojNationPlanStartDate = item.cojNationPlanStartDate,
                    cojNationPlanEndDate = item.cojNationPlanEndDate
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojNationPlans.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojNationPlans/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojNationPlans.FindAsync (id);

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