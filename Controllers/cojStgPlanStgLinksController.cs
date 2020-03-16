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
    public class cojStgPlanStgLinksController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojStgPlanStgLinksController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojStgPlanStgLink
       [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlanStgLink>>> GetAllItem () {
            
            try
            {
                var _cojStgPlanStgLinks = await _context.cojStgPlanStgLinks.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojStgPlanStgLinks.Count != 0)
                {
                    return Ok(_cojStgPlanStgLinks);
                }
                return NoContent();

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgPlanStgLink/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlanStgLink>>> GetAll () {
            
           try
           {
               var _cojStgPlanStgLinks = await _context.cojStgPlanStgLinks.OrderBy (a => a.idRef).ToListAsync ();
               
               if(_cojStgPlanStgLinks.Count != 0) {
                   return Ok(_cojStgPlanStgLinks);
               }

               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgPlanStgLink/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgPlanStgLink>>> GetHistory (long id) {
            
           try
            {
                var _cojStgPlanStgLinks = await _context.cojStgPlanStgLinks.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();
                
                if(_cojStgPlanStgLinks.Count != 0) {
                   return Ok(_cojStgPlanStgLinks);
                }

               return NoContent(); 
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojStgPlanStgLink/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojStgPlanStgLink>> GetItem (long id) {
        
            try
            {
                var _cojStgPlanStgLinks = await _context.cojStgPlanStgLinks.FindAsync (id);

                if (_cojStgPlanStgLinks == null) {
                    return NoContent();
                }

                return Ok(_cojStgPlanStgLinks);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
 
        }
        // POST: api/cojStgPlanStgLink
        [HttpPost]
        public async Task<ActionResult<cojStgPlanStgLink>> CreateItem (cojStgPlanStgLink newItem) {
            
            try
            {

                //check duplicate
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojStgPlanStgLinks.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojStgPlanStgLinks.FindAsync (newItem.id);
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

        // PUT: api/cojStgPlanStgLink/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojStgPlanStgLink item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
            //     var _item = await _context.cojStgPlanStgLinks.FindAsync (id);
            //    // _item.startDate = DateTime.Now.ToString (_culture);
            //     _item.endDate = DateTime.Now.ToString (_culture);
            //     _context.Entry (_item).State = EntityState.Modified;
            //     await _context.SaveChangesAsync ();

                // var _items = await _context.cojStgPlanStgLinks.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojStgPlanStgLinks.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojStgPlanStgLink _itemNew = new cojStgPlanStgLink {
                    idRef = item.idRef,
                    cojStgPlanId = item.cojStgPlanId,
                    cojStgId = item.cojStgId,
                    cojNationStgId = item.cojNationStgId,
                    cojNationStgSectorId = item.cojNationStgSectorId,
                    cojNationStgIssueId = item.cojNationStgIssueId,
                    cojNationPlanId = item.cojNationPlanId,
                    cojNationPlanStgId = item.cojNationPlanStgId,
                    cojNationPlanGuildlineId = item.cojNationPlanGuildlineId,
                    cojNationPlanGuildlineItemId = item.cojNationPlanGuildlineItemId,
                    cojPolicyId = item.cojPolicyId,
                    cojPolicyLevel1Id = item.cojPolicyLevel1Id,
                    cojPolicyLevel2Id = item.cojPolicyLevel2Id
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojStgPlanStgLinks.Add (_itemNew);
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
            
            var _item = await _context.cojStgPlanStgLinks.FindAsync (id);

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