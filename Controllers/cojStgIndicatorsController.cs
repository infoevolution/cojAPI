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
    public class cojStgIndicatorsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojStgIndicatorsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojStgIndicator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgIndicator>>> GetAllItem () {


            try
            {
                var _cojStgIndicators = await _context.cojStgIndicators.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojStgIndicators.Count != 0)
                {
                    return Ok(_cojStgIndicators);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojStgIndicator/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgIndicator>>> GetAll () {
            
            try
            {
                var _cojStgIndicators = await _context.cojStgIndicators.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojStgIndicators.Count != 0)
                {
                    return Ok(_cojStgIndicators);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgIndicator/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgIndicator>>> GetHistory (long id) {
            
            try
            {
                var _cojStgIndicators = await _context.cojStgIndicators.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojStgIndicators.Count != 0)
                {
                    return Ok(_cojStgIndicators);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojStgIndicator/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgIndicator>>> searchName(string term)
        {
            
            try
            {
                var _cojStgIndicators = await _context.cojStgIndicators.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojStgIndicators.Count != 0) {
                   return Ok(_cojStgIndicators);
                }

               return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgIndicator/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojStgIndicator>> GetItem (long id) {

            try
            {
                var _cojStgIndicators = await _context.cojStgIndicators.FindAsync (id);
                
                if (_cojStgIndicators == null) {

                    return NoContent ();

                }

                    return Ok(_cojStgIndicators);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojStgIndicator
        [HttpPost]
        public async Task<ActionResult<cojStgIndicator>> CreateItem (cojStgIndicator newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojStgIndicators.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojStgIndicators.FindAsync (newItem.id);
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

        // PUT: api/cojStgIndicator/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojStgIndicator item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojStgIndicators.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojStgIndicators.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojStgIndicators.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojStgIndicator _itemNew = new cojStgIndicator {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    remark = item.remark,
                    cojStgIndicatorGroupId = item.cojStgIndicatorGroupId,
                    cojStgPlanId = item.cojStgPlanId,
                    cojStgId = item.cojStgId,
                    parentId = item.parentId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojStgIndicators.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojStgIndicator/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojStgIndicators.FindAsync (id);

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