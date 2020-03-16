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
    public class cojWorkActivityController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojWorkActivityController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojWorkActivity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkActivity>>> GetAllItem () {


            try
            {
                var _cojWorkActivities = await _context.cojWorkActivities.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojWorkActivities.Count != 0)
                {
                    return Ok(_cojWorkActivities);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojWorkActivity/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkActivity>>> GetAll () {
            
            try
            {
                var _cojWorkActivities = await _context.cojWorkActivities.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojWorkActivities.Count != 0)
                {
                    return Ok(_cojWorkActivities);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojWorkActivity/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkActivity>>> GetHistory (long id) {
            
            try
            {
                var _cojWorkActivities = await _context.cojWorkActivities.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojWorkActivities.Count != 0)
                {
                    return Ok(_cojWorkActivities);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojWorkActivity/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkActivity>>> searchName(string term)
        {
            
            try
            {
                var _cojWorkActivities = await _context.cojWorkActivities.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojWorkActivities.Count != 0)
                {
                    return Ok(_cojWorkActivities);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojWorkActivity/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojWorkActivity>> GetItem (long id) {

            try
            {
                var cojWorkActivities = await _context.cojWorkActivities.FindAsync (id);
                
                if (cojWorkActivities == null) {

                    return NoContent ();

                }

                    return Ok(cojWorkActivities);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojWorkActivity
        [HttpPost]
        public async Task<ActionResult<cojWorkActivity>> CreateItem (cojWorkActivity newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojWorkActivities.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojWorkActivities.FindAsync (newItem.id);
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

        // PUT: api/cojWorkActivity/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojWorkActivity item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojWorkActivities.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojWorkActivities.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojWorkActivities.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojWorkActivity _itemNew = new cojWorkActivity {
                    idRef = item.idRef,
                    name = item.name,
                    perentId = item.perentId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojWorkActivities.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojWorkActivity/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojWorkActivities.FindAsync (id);

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