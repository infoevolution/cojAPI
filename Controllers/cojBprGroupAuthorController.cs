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
    public class cojBprGroupAuthorController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBprGroupAuthorController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBprGroupAuthor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBprGroupAuthor>>> GetAllItem () {
            try
            {
                var _cojBprGroupAuthor = await _context.cojBprGroupAuthors.OrderBy (a => a.id).ToListAsync ();

                if(_cojBprGroupAuthor.Count != 0)
                {
                    return _cojBprGroupAuthor;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBprGroupAuthor/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBprGroupAuthor>>> GetAll () {
           try
           {
               var _cojBprGroupAuthor = await _context.cojBprGroupAuthors.OrderBy (a => a.id).ToListAsync ();

               if(_cojBprGroupAuthor.Count != 0)
               {
                   return _cojBprGroupAuthor;
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBprGroupAuthor/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBprGroupAuthor>>> GetHistory (long id) {
            
            try
            {
                var _cojBprGroupAuthor = await _context.cojBprGroupAuthors.Where (x => x.id == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBprGroupAuthor.Count != 0)
                {
                    return _cojBprGroupAuthor;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBprGroupAuthor/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBprGroupAuthor>> GetItem (long id) {
            var cojBprGroupAuthors = await _context.cojBprGroupAuthors.FindAsync (id);

            try
            {
                if (cojBprGroupAuthors == null) {
                    return NoContent ();
                }

                return cojBprGroupAuthors;
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojBprGroupAuthor
        [HttpPost]
        public async Task<ActionResult<cojBprGroupAuthor>> CreateItem (cojBprGroupAuthor newItem) {
            
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

                _context.cojBprGroupAuthors.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBprGroupAuthors.FindAsync (newItem.id);
              
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cojBprGroupAuthor/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBprGroupAuthor item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBprGroupAuthors.FindAsync (id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _item.canAccess = false;
                //     _item.canCreate = false;
                //     _item.canRead = false;
                //     _item.canUpdate = false;
                //     _item.canDelete = false;
                //     _item.canGrant = false;
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBprGroupAuthors.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBprGroupAuthors.FindAsync (_itm.id);
                //      _item.endDate = DateTime.Now.ToString (_culture);
                //     _item.canAccess = false;
                //     _item.canCreate = false;
                //     _item.canRead = false;
                //     _item.canUpdate = false;
                //     _item.canDelete = false;
                //     _item.canGrant = false;
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojBprGroupAuthor _itemNew = new cojBprGroupAuthor {
                    idRef=item.idRef,
                    idBprFunction = item.idBprFunction,
                    idUserGroup = item.idUserGroup,
                    description = item.description,
                    canAccess = item.canAccess,
                    canCreate = item.canCreate,
                    canRead = item.canRead,
                    canUpdate = item.canUpdate,
                    canDelete = item.canDelete,
                    canGrant = item.canGrant
                    // startDate = DateTime.Now.ToString(_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBprGroupAuthors.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojBprGroupAuthor/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {                        

            try
            {
                var _item = await _context.cojBprGroupAuthors.FindAsync(id);

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