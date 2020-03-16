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
    public class cojWorkBudgetObjsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojWorkBudgetObjsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojWorkBudgetObjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetObj>>> GetAllItem () {


            try
            {
                var _cojWorkBudgetObj = await _context.cojWorkBudgetObjs.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojWorkBudgetObj.Count != 0)
                {
                    return Ok(_cojWorkBudgetObj);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojWorkBudgetObjs/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetObj>>> GetAll () {
            
            try
            {
                var _cojWorkBudgetObj = await _context.cojWorkBudgetObjs.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojWorkBudgetObj.Count != 0)
                {
                    return Ok(_cojWorkBudgetObj);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojWorkBudgetObjs/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetObj>>> GetHistory (long id) {
            
            try
            {
                var _cojWorkBudgetObj = await _context.cojWorkBudgetObjs.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojWorkBudgetObj.Count != 0)
                {
                    return Ok(_cojWorkBudgetObj);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojWorkBudgetObjs/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetObj>>> searchName(string term)
        {
            
            try
            {
                var _cojWorkBudgetObj = await _context.cojWorkBudgetObjs.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojWorkBudgetObj.Count != 0)
                {
                    return Ok(_cojWorkBudgetObj);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojWorkBudgetObjs/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojWorkBudgetObj>> GetItem (long id) {

            try
            {
                var cojWorkBudgetObj = await _context.cojWorkBudgetObjs.FindAsync (id);
                
                if (cojWorkBudgetObj == null) {

                    return NoContent ();

                }

                    return Ok(cojWorkBudgetObj);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojWorkBudgetObjs
        [HttpPost]
        public async Task<ActionResult<cojWorkBudgetObj>> CreateItem (cojWorkBudgetObj newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojWorkBudgetObjs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojWorkBudgetObjs.FindAsync (newItem.id);
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

        // PUT: api/v1/cojWorkBudgetObjs/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojWorkBudgetObj item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojWorkBudgetObjs.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojWorkBudgetObjs.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojWorkBudgetObjs.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojWorkBudgetObj _itemNew = new cojWorkBudgetObj {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    perentId = item.perentId,
                    cojWorkId = item.cojWorkId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojWorkSubActivityId = item.cojWorkSubActivityId,
                    cojWorkBudgetTypeId = item.cojWorkBudgetTypeId,
                    budgetType = item.budgetType,
                    budgetObj = item.budgetObj
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojWorkBudgetObjs.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojWorkBudgetObjs/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojWorkBudgetObjs.FindAsync (id);

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