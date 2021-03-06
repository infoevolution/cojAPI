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
    public class cojBISWorkSubActivitysController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBISWorkSubActivitysController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojBISWorkSubActivitys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkSubActivity>>> GetAllItem () {


            try
            {
                var _cojBISWorkSubActivitie = await _context.cojBISWorkSubActivities.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBISWorkSubActivitie.Count != 0)
                {
                    return Ok(_cojBISWorkSubActivitie);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkSubActivitys/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkSubActivity>>> GetAll () {
            
            try
            {
                var _cojBISWorkSubActivitie = await _context.cojBISWorkSubActivities.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBISWorkSubActivitie.Count != 0)
                {
                    return Ok(_cojBISWorkSubActivitie);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBISWorkSubActivitys/fy/2561
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkSubActivity>>> fy (long fy) {


            try
            {
                var _cojBISWorkSubActivitie = await _context.cojBISWorkSubActivities.Where (x => x.endDate == "31/12/9999 00:00:00" && x.fy==fy).OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBISWorkSubActivitie.Count != 0)
                {
                    return Ok(_cojBISWorkSubActivitie);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkSubActivitys/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkSubActivity>>> GetHistory (long id) {
            
            try
            {
                var _cojBISWorkSubActivitie = await _context.cojBISWorkSubActivities.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBISWorkSubActivitie.Count != 0)
                {
                    return Ok(_cojBISWorkSubActivitie);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBISWorkSubActivitys/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkSubActivity>>> searchName(string term)
        {
            
            try
            {
                var _cojBISWorkSubActivitie = await _context.cojBISWorkSubActivities.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBISWorkSubActivitie.Count != 0)
                {
                    return Ok(_cojBISWorkSubActivitie);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkSubActivitys/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBISWorkSubActivity>> GetItem (long id) {

            try
            {
                var cojBISWorkSubActivitie = await _context.cojBISWorkSubActivities.FindAsync (id);
                
                if (cojBISWorkSubActivitie == null) {

                    return NoContent ();

                }

                    return Ok(cojBISWorkSubActivitie);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojBISWorkSubActivitys
        [HttpPost]
        public async Task<ActionResult<cojBISWorkSubActivity>> CreateItem (cojBISWorkSubActivity newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBISWorkSubActivities.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBISWorkSubActivities.FindAsync (newItem.id);
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

        // PUT: api/v1/cojBISWorkSubActivitys/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBISWorkSubActivity item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBISWorkSubActivities.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBISWorkSubActivities.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00" && a.fy==item.fy).ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBISWorkSubActivities.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBISWorkSubActivity _itemNew = new cojBISWorkSubActivity {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    perentId = item.perentId,
                    cojWorkId =item.cojWorkId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    fy=item.fy,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBISWorkSubActivities.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojBISWorkSubActivitys/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBISWorkSubActivities.FindAsync (id);

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