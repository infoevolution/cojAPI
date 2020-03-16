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
    public class cojNationPlanGuildlinesController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojNationPlanGuildlinesController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojNationPlanGuildlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGuildline>>> GetAllItem () {


            try
            {
                var _cojNationPlanGuildline = await _context.cojNationPlanGuildlines.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojNationPlanGuildline.Count != 0)
                {
                    return Ok(_cojNationPlanGuildline);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlanGuildlines/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGuildline>>> GetAll () {
            
            try
            {
                var _cojNationPlanGuildline = await _context.cojNationPlanGuildlines.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojNationPlanGuildline.Count != 0)
                {
                    return Ok(_cojNationPlanGuildline);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlanGuildlines/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGuildline>>> GetHistory (long id) {
            
            try
            {
                var _cojNationPlanGuildline = await _context.cojNationPlanGuildlines.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojNationPlanGuildline.Count != 0)
                {
                    return Ok(_cojNationPlanGuildline);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationPlanGuildlines/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationPlanGuildline>>> searchName(string term)
        {
            
            try
            {
                var _cojNationPlanGuildline = await _context.cojNationPlanGuildlines.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojNationPlanGuildline.Count != 0)
                {
                    return Ok(_cojNationPlanGuildline);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationPlanGuildlines/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojNationPlanGuildline>> GetItem (long id) {

            try
            {
                var cojNationPlanGuildline = await _context.cojNationPlanGuildlines.FindAsync (id);
                
                if (cojNationPlanGuildline == null) {

                    return NoContent ();

                }

                    return Ok(cojNationPlanGuildline);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojNationPlanGuildlines
        [HttpPost]
        public async Task<ActionResult<cojNationPlanGuildline>> CreateItem (cojNationPlanGuildline newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojNationPlanGuildlines.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojNationPlanGuildlines.FindAsync (newItem.id);
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

        // PUT: api/v1/cojNationPlanGuildlines/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojNationPlanGuildline item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojNationPlanGuildlines.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojNationPlanGuildlines.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojNationPlanGuildlines.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojNationPlanGuildline _itemNew = new cojNationPlanGuildline {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojNationPlanId = item.cojNationPlanId,
                    cojNationPlanStgId = item.cojNationPlanStgId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojNationPlanGuildlines.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojNationPlanGuildlines/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojNationPlanGuildlines.FindAsync (id);

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