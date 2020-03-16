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
    public class cojGroupMembersController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojGroupMembersController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojGroupMember
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojGroupMember>>> GetAllItem () {
            try
            {
                var _cojGroupMember = await _context.cojGroupMembers.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojGroupMember.Count != 0)
                {
                    return _cojGroupMember;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojGroupMember/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojGroupMember>>> GetAll () {
           try
           {
               var _cojGroupMember = await _context.cojGroupMembers.OrderBy (a => a.idRef).ToListAsync ();

               if(_cojGroupMember.Count != 0)
               {
                   return _cojGroupMember;
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojGroupMember/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojGroupMember>>> GetHistory (long id) {
            
            try
            {
                var _cojGroupMember = await _context.cojGroupMembers.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojGroupMember.Count != 0)
                {
                    return _cojGroupMember;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojGroupMember/getGroupMember
        [Route ("[action]/{groupId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojGroupMember>>> getGroupMember (long groupId) {
            
            try
            {
                var _cojGroupMember = await _context.cojGroupMembers.Where (x => x.groupId == groupId).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojGroupMember.Count != 0)
                {
                    return _cojGroupMember;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojGroupMember/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojGroupMember>> GetItem (long id) {
            var cojGroupMember = await _context.cojGroupMembers.FindAsync (id);

            try
            {
                if (cojGroupMember == null) {
                    return NoContent ();
                }

                return cojGroupMember;
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojGroupMember
        [HttpPost]
        public async Task<ActionResult<cojGroupMember>> CreateItem (cojGroupMember newItem) {
            
            //check duplicate item id, code, name
            //...
            try
            {
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //

                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojGroupMembers.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojGroupMembers.FindAsync (newItem.id);
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

        // PUT: api/cojGroupMember/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojGroupMember item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojGroupMembers.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojGroupMembers.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojGroupMembers.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojGroupMember _itemNew = new cojGroupMember {
                    idRef = item.idRef,
                    itemNo = item.itemNo,
                    groupId = item.groupId,
                    userId = item.userId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojGroupMembers.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojGroupMember/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojGroupMembers.FindAsync (id);

            try
            {
                if (_item == null) {
                    return BadRequest ();
                }

                //update endDate
                _item.endDate = DateTime.Now.ToString (_culture);
                _context.Entry (_item).State = EntityState.Modified;
                await _context.SaveChangesAsync ();

                return Ok (_item);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
    }
}