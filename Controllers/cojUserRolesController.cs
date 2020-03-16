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
    public class cojUserRolesController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojUserRolesController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojUserRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUserRole>>> GetAllItem () {
            try
            {
                var _cojUserRole = await _context.cojUserRoles.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojUserRole.Count != 0)
                {
                    return _cojUserRole;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojUserRole/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUserRole>>> GetAll () {
           try
           {
               var _cojUserRole = await _context.cojUserRoles.OrderBy (a => a.idRef).ToListAsync ();

               if(_cojUserRole.Count != 0)
               {
                   return _cojUserRole;
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojUserRole/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUserRole>>> GetHistory (long id) {
            
            try
            {
                var _cojUserRole = await _context.cojUserRoles.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojUserRole.Count != 0)
                {
                    return _cojUserRole;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get by groupId
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUserRole>>> GetUserId (long id) {
            
            try
            {
                var _cojUserRole = await _context.cojUserRoles.Where (x => x.userId == id && x.endDate == "31/12/9999 00:00:00").ToListAsync ();

                if(_cojUserRole.Count != 0)
                {
                    return _cojUserRole;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojUserRole/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojUserRole>> GetItem (long id) {
            var cojUserRole = await _context.cojUserRoles.FindAsync (id);

            try
            {
                if (cojUserRole == null) {
                    return NoContent ();
                }

                return cojUserRole;
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojUserRole
        [HttpPost]
        public async Task<ActionResult<cojUserRole>> CreateItem (cojUserRole newItem) {
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //

                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojUserRoles.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojUserRoles.FindAsync (newItem.id);
                // _item.startDate = DateTime.Now.ToString (_culture);
                // _item.endDate = "31/12/9999 00:00:00";
                // _item.idRef = newItem.id;
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);
                //return Ok();

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cojUserRole/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojUserRole item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojUserRoles.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojUserRoles.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojUserRoles.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojUserRole _itemNew = new cojUserRole {
                    idRef = item.idRef,
                    userId = item.userId,
                    cmd = item.cmd,
                    add = item.add,
                    edit = item.edit,
                    view = item.view,
                    remove = item.remove,
                    fullcontrol = item.fullcontrol
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojUserRoles.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojUserRole/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojUserRoles.FindAsync (id);

            try
            {
                if (_item == null) {
                    return BadRequest ();
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