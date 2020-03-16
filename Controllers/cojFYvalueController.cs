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
    public class cojFYvalueController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojFYvalueController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojFYvalue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojFYvalue>>> GetAllItem () {
            try
            {
                var _cojFYvalue  = await _context.cojFYvalues.ToListAsync ();

                if(_cojFYvalue.Count != 0)
                {
                    return _cojFYvalue;
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/cojFYvalue/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojFYvalue>> GetItem (long id) {
            var cojFYvalue = await _context.cojFYvalues.FindAsync (id);

            try
            {
                if (cojFYvalue == null) {
                    return NoContent ();
                }

                return cojFYvalue;
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojFYvalue
        [HttpPost]
        public async Task<ActionResult<cojFYvalue>> CreateItem (cojFYvalue newItem) {
            
            try
            {
                _context.cojFYvalues.Add (newItem);
                await _context.SaveChangesAsync ();

                //initial new item
                var _item = await _context.cojFYvalues.FindAsync (newItem.id);
                _context.Entry (_item).State = EntityState.Modified;
                await _context.SaveChangesAsync ();

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cojFYvalue/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojFYvalue item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojFYvalues.FindAsync (id);
                _context.Entry (item).State = EntityState.Modified;
                await _context.SaveChangesAsync ();

                return Ok (item);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojFYvalue/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojFYvalues.FindAsync (id);

            try
            {
                if (_item == null) {
                    return NoContent ();
                }

                //update endDate
                _context.Remove (_item);
                await _context.SaveChangesAsync();

                return Ok ();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
    }
}