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
    public class cojStgOperationsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojStgOperationsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojStgOperation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgOperation>>> GetAllItem () {


            try
            {
                var _cojStgOperations = await _context.cojStgOperations.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojStgOperations.Count != 0)
                {
                    return Ok(_cojStgOperations);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojStgOperation/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgOperation>>> GetAll () {
            
            try
            {
                var _cojStgOperations = await _context.cojStgOperations.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojStgOperations.Count != 0)
                {
                    return Ok(_cojStgOperations);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojStgOperation/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgOperation>>> GetHistory (long id) {
            
            try
            {
                var _cojStgOperations = await _context.cojStgOperations.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojStgOperations.Count != 0)
                {
                    return Ok(_cojStgOperations);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojStgOperation/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojStgOperation>>> searchName(string term)
        {
            
            try
            {
                var _cojStgOperations = await _context.cojStgOperations.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojStgOperations.Count != 0) {
                   return Ok(_cojStgOperations);
                }

               return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/cojStgOperation/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojStgOperation>> GetItem (long id) {

            try
            {
                var _cojStgOperations = await _context.cojStgOperations.FindAsync (id);
                
                if (_cojStgOperations == null) {

                    return NoContent ();

                }

                    return Ok(_cojStgOperations);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojStgOperation
        [HttpPost]
        public async Task<ActionResult<cojStgOperation>> CreateItem (cojStgOperation newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojStgOperations.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojStgOperations.FindAsync (newItem.id);
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

        // PUT: api/cojStgOperation/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojStgOperation item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojStgOperations.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojStgOperations.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojStgOperations.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojStgOperation _itemNew = new cojStgOperation {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    remark = item.remark,
                    cojStgIndicatorGroupId = item.cojStgIndicatorGroupId,
                    cojStgPlanId = item.cojStgPlanId,
                    cojStgId = item.cojStgId,
                    parentId = item.parentId
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojStgOperations.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojStgOperation/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojStgOperations.FindAsync (id);

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