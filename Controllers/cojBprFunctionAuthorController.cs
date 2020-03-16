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
    public class cojBprFunctionAuthorController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBprFunctionAuthorController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBprFunctionAuthor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBprFunctionAuthor>>> GetAllItem () {
            try
            {
                var _cojBprFunctionAuthor = await _context.cojBprFunctionAuthors.Where(x=> x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBprFunctionAuthor.Count != 0)
                {
                    return _cojBprFunctionAuthor;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBprFunctionAuthor/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBprFunctionAuthor>>> GetAll () {
           try
           {
               var _cojBprFunctionAuthor = await _context.cojBprFunctionAuthors.OrderBy (a => a.idRef).ToListAsync ();
               
               if(_cojBprFunctionAuthor.Count != 0)
               {
                   return _cojBprFunctionAuthor;
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBprFunctionAuthor/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBprFunctionAuthor>>> GetHistory (long id) {
            
            try
            {
                var _cojBprFunctionAuthor = await _context.cojBprFunctionAuthors.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBprFunctionAuthor.Count != 0)
                {
                    return _cojBprFunctionAuthor;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojUserGroup/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBprFunctionAuthor>>> searchName(string term)
        {
            
            try
            {
                var _cojBprFunctionAuthor = await _context.cojBprFunctionAuthors.Where(x => x.description.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBprFunctionAuthor.Count != 0)
                {
                    return _cojBprFunctionAuthor;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBprFunctionAuthor/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBprFunctionAuthor>> GetItem (long id) {
            var cojBprFunctionAuthors = await _context.cojBprFunctionAuthors.FindAsync (id);

            try
            {
                if (cojBprFunctionAuthors == null) {
                    return NoContent ();
                }

                return cojBprFunctionAuthors;
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojBprFunctionAuthor
        [HttpPost]
        public async Task<ActionResult<cojBprFunctionAuthor>> CreateItem (cojBprFunctionAuthor newItem) {
            
            //check duplicate item id, code, name
            //...
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBprFunctionAuthors.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBprFunctionAuthors.FindAsync (newItem.id);
              
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

        // PUT: api/cojBprFunctionAuthor/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBprFunctionAuthor item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBprFunctionAuthors.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                //     _item.canAccess = false;
                //     _item.canCreate = false;
                //     _item.canRead = false;
                //     _item.canUpdate = false;
                //     _item.canDelete = false;
                //     _item.canGrant = false;
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBprFunctionAuthors.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBprFunctionAuthors.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _item.canAccess = false;
                //     _item.canCreate = false;
                //     _item.canRead = false;
                //     _item.canUpdate = false;
                //     _item.canDelete = false;
                //     _item.canGrant = false;
                // _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojBprFunctionAuthor _itemNew = new cojBprFunctionAuthor {
                    idRef = item.idRef,
                    idBprFunction = item.idBprFunction,
                    cojRoles = item.cojRoles,
                    canAccess = item.canAccess,
                    canCreate = item.canCreate,
                    canRead = item.canRead,
                    canUpdate = item.canUpdate,
                    canDelete = item.canDelete,
                    canGrant = item.canGrant
                    // startDate = DateTime.Now.ToString(_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBprFunctionAuthors.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojBprFunctionAuthor/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {                        

            try
            {
                var _item = await _context.cojBprFunctionAuthors.FindAsync (id);

                if (_item == null) {
                    return NoContent ();
                }

                //update endDate
                 
                _item.endDate = DateTime.Now.ToString (_culture);
                 
                    _item.canAccess = false;
                    _item.canCreate = false;
                    _item.canRead = false;
                    _item.canUpdate = false;
                    _item.canDelete = false;
                    _item.canGrant = false;
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