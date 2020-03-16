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
    public class cojNationPlanGoalsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojNationPlanGoalsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojNationPlanGoals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoal>>> GetAllItem () {


            try
            {
                var _cojNationPlanGoal = await _context.cojNationPlanGoals.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojNationPlanGoal.Count != 0)
                {
                    return Ok(_cojNationPlanGoal);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlanGoals/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoal>>> GetAll () {
            
            try
            {
                var _cojNationPlanGoal = await _context.cojNationPlanGoals.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojNationPlanGoal.Count != 0)
                {
                    return Ok(_cojNationPlanGoal);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlanGoals/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoal>>> GetHistory (long id) {
            
            try
            {
                var _cojNationPlanGoal = await _context.cojNationPlanGoals.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojNationPlanGoal.Count != 0)
                {
                    return Ok(_cojNationPlanGoal);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlanGoals/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGoal>>> searchName(string term)
        {
            
            try
            {
                var _cojNationPlanGoal = await _context.cojNationPlanGoals.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojNationPlanGoal.Count != 0)
                {
                    return Ok(_cojNationPlanGoal);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlanGoals/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojNationPlanGoal>> GetItem (long id) {

            try
            {
                var cojNationPlanGoal = await _context.cojNationPlanGoals.FindAsync (id);
                
                if (cojNationPlanGoal == null) {

                    return NoContent ();

                }

                    return Ok(cojNationPlanGoal);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojNationPlanGoals
        [HttpPost]
        public async Task<ActionResult<cojNationPlanGoal>> CreateItem (cojNationPlanGoal newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojNationPlanGoals.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojNationPlanGoals.FindAsync (newItem.id);
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



        //------------ post array for postman
        // [Route("[action]")]
        // [HttpPost]
        // public async Task<ActionResult> CreateArray ([FromBody]cojNationPlanGoalArray newItem) {
            
            
        //     try
        //     {
        //         var rt = newItem.cojNationPlanGoal;

        //         foreach (var a in rt)
        //         {
        //             if(a.id != 0){
        //                 return NoContent();
        //             }
        //             _context.cojNationPlanGoals.Add (a);
        //             await _context.SaveChangesAsync ();

        //             //initial new item
        //             var _item = await _context.cojNationPlanGoals.FindAsync (a.id);
        //             _item.startDate = DateTime.Now.ToString (_culture);
        //             _item.endDate = "31/12/9999 00:00:00";
        //             _item.idRef = a.id;
        //             _context.Entry (_item).State = EntityState.Modified;
        //             await _context.SaveChangesAsync ();

        //         }
        //         return Ok();
                
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }

        // }
        //------------- end post array

        // PUT: api/v1/cojNationPlanGoals/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojNationPlanGoal item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojNationPlanGoals.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojNationPlanGoals.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojNationPlanGoals.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojNationPlanGoal _itemNew = new cojNationPlanGoal {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojNationPlanId = item.cojNationPlanId,
                    cojNationPlanStgId = item.cojNationPlanStgId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojNationPlanGoals.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojNationPlanGoals/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojNationPlanGoals.FindAsync (id);

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