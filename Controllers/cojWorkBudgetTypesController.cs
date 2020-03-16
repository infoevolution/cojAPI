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
    public class cojWorkBudgetTypesController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojWorkBudgetTypesController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojWorkBudgetTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetType>>> GetAllItem () {


            try
            {
                var _cojWorkBudgetType = await _context.cojWorkBudgetTypes.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojWorkBudgetType.Count != 0)
                {
                    return Ok(_cojWorkBudgetType);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojWorkBudgetTypes/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetType>>> GetAll () {
            
            try
            {
                var _cojWorkBudgetType = await _context.cojWorkBudgetTypes.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojWorkBudgetType.Count != 0)
                {
                    return Ok(_cojWorkBudgetType);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojWorkBudgetTypes/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetType>>> GetHistory (long id) {
            
            try
            {
                var _cojWorkBudgetType = await _context.cojWorkBudgetTypes.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojWorkBudgetType.Count != 0)
                {
                    return Ok(_cojWorkBudgetType);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojWorkBudgetTypes/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojWorkBudgetType>>> searchName(string term)
        {
            
            try
            {
                var _cojWorkBudgetType = await _context.cojWorkBudgetTypes.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojWorkBudgetType.Count != 0)
                {
                    return Ok(_cojWorkBudgetType);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojWorkBudgetTypes/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojWorkBudgetType>> GetItem (long id) {

            try
            {
                var cojWorkBudgetType = await _context.cojWorkBudgetTypes.FindAsync (id);
                
                if (cojWorkBudgetType == null) {

                    return NoContent ();

                }

                    return Ok(cojWorkBudgetType);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojWorkBudgetTypes
        [HttpPost]
        public async Task<ActionResult<cojWorkBudgetType>> CreateItem (cojWorkBudgetType newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojWorkBudgetTypes.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojWorkBudgetTypes.FindAsync (newItem.id);
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

        // PUT: api/v1/cojWorkBudgetTypes/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojWorkBudgetType item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojWorkBudgetTypes.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojWorkBudgetTypes.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojWorkBudgetTypes.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojWorkBudgetType _itemNew = new cojWorkBudgetType {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    perentId = item.perentId,
                    cojWorkId = item.cojWorkId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojWorkSubActivityId = item.cojWorkSubActivityId,
                    budgetType = item.budgetType
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojWorkBudgetTypes.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojWorkBudgetTypes/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojWorkBudgetTypes.FindAsync (id);

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