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
    public class cojStgPlanStgsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojStgPlanStgsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojStgPlanStg
       [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlanStg>>> GetAllItem () {
            
            try
            {
                var _cojStgPlanStgs = await _context.cojStgPlanStgs.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojStgPlanStgs.Count != 0)
                {
                    return Ok(_cojStgPlanStgs);
                }
                return NoContent();

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgPlanStg/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlanStg>>> GetAll () {
            
           try
           {
               var _cojStgPlanStgs = await _context.cojStgPlanStgs.OrderBy (a => a.idRef).ToListAsync ();
               
               if(_cojStgPlanStgs.Count != 0) {
                   return Ok(_cojStgPlanStgs);
               }

               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgPlanStg/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlanStg>>> GetHistory (long id) {
            
           try
            {
                var _cojStgPlanStgs = await _context.cojStgPlanStgs.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();
                
                if(_cojStgPlanStgs.Count != 0) {
                   return Ok(_cojStgPlanStgs);
                }

               return NoContent(); 
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojStgPlanStg/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojStgPlanStg>> GetItem (long id) {
        
            try
            {
                var _cojStgPlanStgs = await _context.cojStgPlanStgs.FindAsync (id);

                if (_cojStgPlanStgs == null) {
                    return NoContent();
                }

                return Ok(_cojStgPlanStgs);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
 
        }
        // POST: api/cojStgPlanStg
        [HttpPost]
        public async Task<ActionResult<cojStgPlanStg>> CreateItem (cojStgPlanStg newItem) {
            
            try
            {

                //check duplicate
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojStgPlanStgs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;
                
                //_context.Entry (newItem).State = EntityState.Modified;
                
                //initial new item
                //var _item = await _context.cojStgPlanStgs.FindAsync (newItem.id);
                // _item.startDate = DateTime.Now.ToString (_culture);
                // _item.endDate = "31/12/9999 00:00:00";           
                //_item.idRef = newItem.id;
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojStgPlanStg/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojStgPlanStg item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
            //     var _item = await _context.cojStgPlanStgs.FindAsync (id);
            //    // _item.startDate = DateTime.Now.ToString (_culture);
            //     _item.endDate = DateTime.Now.ToString (_culture);
            //     _context.Entry (_item).State = EntityState.Modified;
            //     await _context.SaveChangesAsync ();

                // var _items = await _context.cojStgPlanStgs.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojStgPlanStgs.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojStgPlanStg _itemNew = new cojStgPlanStg {
                    idRef = item.idRef,
                    cojStgPlanId = item.cojStgPlanId,
                    cojStgId = item.cojStgId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojStgPlanStgs.Add (_itemNew);
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
            
            var _item = await _context.cojStgPlanStgs.FindAsync (id);

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