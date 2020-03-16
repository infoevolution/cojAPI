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
    public class cojBGPlanWorkplanActivityIndicatorsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplanActivityIndicatorsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanWorkplanActivityIndicators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityIndicator>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplanActivityIndicators = await _context.cojBGPlanWorkplanActivityIndicators.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplanActivityIndicators.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityIndicators);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanWorkplanActivityIndicators/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityIndicator>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplanActivityIndicators = await _context.cojBGPlanWorkplanActivityIndicators.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplanActivityIndicators.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityIndicators);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivityIndicators/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityIndicator>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplanActivityIndicators = await _context.cojBGPlanWorkplanActivityIndicators.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplanActivityIndicators.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityIndicators);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojBGPlanWorkplanActivityIndicators/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityIndicator>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanWorkplanActivityIndicators = await _context.cojBGPlanWorkplanActivityIndicators.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojBGPlanWorkplanActivityIndicators.Count != 0) {
                   return Ok(_cojBGPlanWorkplanActivityIndicators);
                }

               return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivityIndicators/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplanActivityIndicator>> GetItem (long id) {

            try
            {
                var _cojBGPlanWorkplanActivityIndicators = await _context.cojBGPlanWorkplanActivityIndicators.FindAsync (id);
                
                if (_cojBGPlanWorkplanActivityIndicators == null) {

                    return NoContent ();

                }

                    return Ok(_cojBGPlanWorkplanActivityIndicators);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanWorkplanActivityIndicators
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplanActivityIndicator>> CreateItem (cojBGPlanWorkplanActivityIndicator newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanWorkplanActivityIndicators.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplanActivityIndicators.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanWorkplanActivityIndicators/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplanActivityIndicator item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBGPlanWorkplanActivityIndicators.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanWorkplanActivityIndicators.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplanActivityIndicators.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }
                
                //Add new
                cojBGPlanWorkplanActivityIndicator _itemNew = new cojBGPlanWorkplanActivityIndicator {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojStgPlanId = item.cojStgPlanId,
                    cojStgIndicatorId = item.cojStgIndicatorId,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanWorkplanActivityIndicators.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanWorkplanActivityIndicators/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplanActivityIndicators.FindAsync (id);

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