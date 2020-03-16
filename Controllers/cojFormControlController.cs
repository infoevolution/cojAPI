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
    public class cojFormControlController : ControllerBase {
        private readonly cojDBContext _context;
        // private CultureInfo _culture;
        public cojFormControlController (cojDBContext context) {
            _context = context;
            // _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojFormControl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojFormControl>>> GetAllItem () {


            try
            {
                var _cojFormControl = await _context.cojFormControls.ToListAsync ();
                
                if(_cojFormControl.Count != 0)
                {
                    return _cojFormControl;
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojFormControl/search
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojFormControl>>> search(string term)
        {
            
            try
            {
                var _cojFormControl = await _context.cojFormControls.Where(x => x.label.ToLowerInvariant().Contains(term) || x.key.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojFormControl.Count != 0)
                {
                    return _cojFormControl;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojFormControl/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojFormControl>> GetItem (long id) {

            try
            {
                var cojFormControl = await _context.cojFormControls.FindAsync (id);
                
                if (cojFormControl == null) {

                    return NoContent ();

                }

                    return cojFormControl;

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojFormControl
        [HttpPost]
        public async Task<ActionResult<cojFormControl>> CreateItem (cojFormControl newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                

                _context.cojFormControls.Add (newItem);
                await _context.SaveChangesAsync ();

                //initial new item
                // var _item = await _context.cojFormControls.FindAsync (newItem.id);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojFormControl/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojFormControl item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                var _item = await _context.cojFormControls.FindAsync (id);
                _item.key = item.key;
                _item.label = item.label;
                _item.value = item.value;
                _item.type = item.type;
                _item.controlType = item.controlType;
                _item.categoryId = item.categoryId;
                _item.required = item.required;
                _item.order = item.order;
                _item.options = item.options;

                _context.Entry (_item).State = EntityState.Modified;
                await _context.SaveChangesAsync ();

                return Ok (_item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojFormControl/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {                    

            try
            {
                var _item = await _context.cojFormControls.FindAsync (id);
                
                if (_item == null) {
                    return NoContent ();
                }

                //Delete
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