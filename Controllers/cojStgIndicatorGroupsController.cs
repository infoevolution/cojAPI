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
    public class cojStgIndicatorGroupsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojStgIndicatorGroupsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojStgIndicatorGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgIndicatorGroup>>> GetAllItem () {

            try
            {
                var _cojStgIndicatorGroups = await _context.cojStgIndicatorGroups.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojStgIndicatorGroups.Count != 0)
                {
                    return Ok(_cojStgIndicatorGroups);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojStgIndicatorGroup/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgIndicatorGroup>>> GetAll () {
            
            try
            {
                var _cojStgIndicatorGroups = await _context.cojStgIndicatorGroups.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojStgIndicatorGroups.Count != 0)
                {
                    return Ok(_cojStgIndicatorGroups);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgIndicatorGroup/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgIndicatorGroup>>> GetHistory (long id) {
            
            try
            {
                var _cojStgIndicatorGroups = await _context.cojStgIndicatorGroups.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojStgIndicatorGroups.Count != 0)
                {
                    return Ok(_cojStgIndicatorGroups);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojStgIndicatorGroup/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojStgIndicatorGroup>> GetItem (long id) {

            try
            {
                var _cojStgIndicatorGroups = await _context.cojStgIndicatorGroups.FindAsync (id);
                
                if (_cojStgIndicatorGroups == null) {

                    return NoContent ();

                }

                    return Ok(_cojStgIndicatorGroups);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojStgIndicatorGroup
        [HttpPost]
        public async Task<ActionResult<cojStgIndicatorGroup>> CreateItem (cojStgIndicatorGroup newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojStgIndicatorGroups.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojStgIndicatorGroups.FindAsync (newItem.id);
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

        // PUT: api/cojStgIndicatorGroup/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojStgIndicatorGroup item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojStgIndicatorGroups.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojStgIndicatorGroups.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojStgIndicatorGroups.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojStgIndicatorGroup _itemNew = new cojStgIndicatorGroup {
                    idRef = item.idRef,
                    indicatorGroup = item.indicatorGroup,
                    cojStgId = item.cojStgId,
                    cojStgPlanId = item.cojStgPlanId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojStgIndicatorGroups.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojStgIndicatorGroup/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojStgIndicatorGroups.FindAsync (id);

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