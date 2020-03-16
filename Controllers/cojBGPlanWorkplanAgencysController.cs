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
    public class cojBGPlanWorkplanAgenciesController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplanAgenciesController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanWorkplanAgency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanAgency>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplanAgency = await _context.cojBGPlanWorkplanAgencies.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplanAgency.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanAgency);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanWorkplanAgency/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanAgency>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplanAgency = await _context.cojBGPlanWorkplanAgencies.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplanAgency.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanAgency);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanAgency/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanAgency>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplanAgency = await _context.cojBGPlanWorkplanAgencies.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplanAgency.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanAgency);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanAgency/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanAgency>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanWorkplanAgency = await _context.cojBGPlanWorkplanAgencies.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanWorkplanAgency.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanAgency);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanWorkplanAgency/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplanAgency>> GetItem (long id) {

            try
            {
                var cojBGPlanWorkplanAgency = await _context.cojBGPlanWorkplanAgencies.FindAsync (id);
                
                if (cojBGPlanWorkplanAgency == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanWorkplanAgency);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanWorkplanAgency
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplanAgency>> CreateItem (cojBGPlanWorkplanAgency newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanWorkplanAgencies.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplanAgencies.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanWorkplanAgency/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplanAgency item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanWorkplanAgencies.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanWorkplanAgencies.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplanAgencies.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanWorkplanAgency _itemNew = new cojBGPlanWorkplanAgency {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojBGWorkplanTypeId = item.cojBGWorkplanTypeId,
                    cojBGPlanWorkplanActivityId = item.cojBGPlanWorkplanActivityId,
                    cojAgencyBudgetRoleId = item.cojAgencyBudgetRoleId,
                    cojAgencyId = item.cojAgencyId,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanWorkplanAgencies.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanWorkplanAgency/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplanAgencies.FindAsync (id);

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