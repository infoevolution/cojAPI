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
    public class cojPeriodsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojPeriodsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojPeriod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojPeriod>>> GetAllItem () {


            try
            {
                var _cojPeriod = await _context.cojPeriods.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojPeriod.Count != 0)
                {
                    return Ok(_cojPeriod);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojPeriod/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojPeriod>>> GetAll () {
            
            try
            {
                var _cojPeriod = await _context.cojPeriods.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojPeriod.Count != 0)
                {
                    return Ok(_cojPeriod);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojPeriod/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojPeriod>>> GetHistory (long id) {
            
            try
            {
                var _cojPeriod = await _context.cojPeriods.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojPeriod.Count != 0)
                {
                    return Ok(_cojPeriod);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojPeriod/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojPeriod>>> searchName(string term)
        {
            
            try
            {
                var _cojPeriod = await _context.cojPeriods.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojPeriod.Count != 0)
                {
                    return Ok(_cojPeriod);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojPeriod/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojPeriod>> GetItem (long id) {

            try
            {
                var cojPeriod = await _context.cojPeriods.FindAsync (id);
                
                if (cojPeriod == null) {

                    return NoContent ();

                }

                    return Ok(cojPeriod);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojPeriod
        [HttpPost]
        public async Task<ActionResult<cojPeriod>> CreateItem (cojPeriod newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojPeriods.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojPeriods.FindAsync (newItem.id);
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

        // PUT: api/cojPeriod/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojPeriod item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojPeriods.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojPeriods.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojPeriods.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojPeriod _itemNew = new cojPeriod {
                    idRef = item.idRef,
                    name = item.name,
                    remark = item.remark,
                    periodType = item.periodType,
                    fy = item.fy,
                    PeriodStartDate = item.PeriodStartDate,
                    PeriodEndDate = item.PeriodEndDate
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojPeriods.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojPeriod/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojPeriods.FindAsync (id);

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