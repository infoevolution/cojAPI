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
    public class cojStgPlansController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojStgPlansController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojStgPlan
       [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlan>>> GetAllItem () {
            
            try
            {
                var _cojStgPlans = await _context.cojStgPlans.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojStgPlans.Count != 0)
                {
                    return Ok(_cojStgPlans);
                }
                return NoContent();

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgPlan/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlan>>> GetAll () {
            
           try
           {
               var _cojStgPlans = await _context.cojStgPlans.OrderBy (a => a.idRef).ToListAsync ();
               
               if(_cojStgPlans.Count != 0) {
                   return Ok(_cojStgPlans);
               }

               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgPlan/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlan>>> GetHistory (long id) {
            
           try
            {
                var _cojStgPlans = await _context.cojStgPlans.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();
                
                if(_cojStgPlans.Count != 0) {
                   return Ok(_cojStgPlans);
                }

               return NoContent(); 
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojStgPlan/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlan>>> searchName(string term)
        {
            
            try
            {
                var _cojStgPlans = await _context.cojStgPlans.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojStgPlans.Count != 0) {
                   return Ok(_cojStgPlans);
                }

               return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgPlan/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojStgPlan>> GetItem (long id) {
        
            try
            {
                var _cojStgPlans = await _context.cojStgPlans.FindAsync (id);

                if (_cojStgPlans == null) {
                    return NoContent();
                }

                return Ok(_cojStgPlans);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
 
        }
        // POST: api/cojStgPlan
        [HttpPost]
        public async Task<ActionResult<cojStgPlan>> CreateItem (cojStgPlan newItem) {
            
            try
            {

                //check duplicate
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojStgPlans.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojStgPlans.FindAsync (newItem.id);
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

        // PUT: api/cojStgPlan/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojStgPlan item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
            //     var _item = await _context.cojStgPlans.FindAsync (id);
            //    // _item.startDate = DateTime.Now.ToString (_culture);
            //     _item.endDate = DateTime.Now.ToString (_culture);
            //     _context.Entry (_item).State = EntityState.Modified;
            //     await _context.SaveChangesAsync ();

                // var _items = await _context.cojStgPlans.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojStgPlans.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojStgPlan _itemNew = new cojStgPlan {
                    idRef = item.idRef,
                    name = item.name,
                    vision = item.vision,
                    active = item.active,
                    remark = item.remark,
                    cojStgPlanStartDate = item.cojStgPlanStartDate,
                    cojStgPlanEndDate = item.cojStgPlanEndDate
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojStgPlans.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojStgPlan/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojStgPlans.FindAsync (id);

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