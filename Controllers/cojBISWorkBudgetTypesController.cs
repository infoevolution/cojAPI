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
    public class cojBISWorkBudgetTypesController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBISWorkBudgetTypesController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojBISWorkBudgetTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetType>>> GetAllItem () {


            try
            {
                var _cojBISWorkBudgetType = await _context.cojBISWorkBudgetTypes.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBISWorkBudgetType.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetType);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkBudgetTypes/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetType>>> GetAll () {
            
            try
            {
                var _cojBISWorkBudgetType = await _context.cojBISWorkBudgetTypes.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBISWorkBudgetType.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetType);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBISWorkBudgetTypes/fy/2561
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetType>>> fy (long fy) {


            try
            {
                var _cojBISWorkBudgetType = await _context.cojBISWorkBudgetTypes.Where (x => x.endDate == "31/12/9999 00:00:00" && x.fy==fy).OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBISWorkBudgetType.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetType);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkBudgetTypes/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetType>>> GetHistory (long id) {
            
            try
            {
                var _cojBISWorkBudgetType = await _context.cojBISWorkBudgetTypes.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBISWorkBudgetType.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetType);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBISWorkBudgetTypes/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetType>>> searchName(string term)
        {
            
            try
            {
                var _cojBISWorkBudgetType = await _context.cojBISWorkBudgetTypes.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBISWorkBudgetType.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetType);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkBudgetTypes/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBISWorkBudgetType>> GetItem (long id) {

            try
            {
                var cojBISWorkBudgetType = await _context.cojBISWorkBudgetTypes.FindAsync (id);
                
                if (cojBISWorkBudgetType == null) {

                    return NoContent ();

                }

                    return Ok(cojBISWorkBudgetType);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojBISWorkBudgetTypes
        [HttpPost]
        public async Task<ActionResult<cojBISWorkBudgetType>> CreateItem (cojBISWorkBudgetType newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBISWorkBudgetTypes.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBISWorkBudgetTypes.FindAsync (newItem.id);
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

        // PUT: api/v1/cojBISWorkBudgetTypes/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBISWorkBudgetType item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBISWorkBudgetTypes.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBISWorkBudgetTypes.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00" && a.fy==item.fy).ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBISWorkBudgetTypes.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBISWorkBudgetType _itemNew = new cojBISWorkBudgetType {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    perentId = item.perentId,
                    cojWorkId = item.cojWorkId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojWorkSubActivityId = item.cojWorkSubActivityId,
                    budgetType = item.budgetType,
                    fy=item.fy,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBISWorkBudgetTypes.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojBISWorkBudgetTypes/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBISWorkBudgetTypes.FindAsync (id);

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