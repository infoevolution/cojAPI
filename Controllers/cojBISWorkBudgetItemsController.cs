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
    public class cojBISWorkBudgetItemsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBISWorkBudgetItemsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojBISWorkBudgetItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetItem>>> GetAllItem () {


            try
            {
                var _cojBISWorkBudgetItem = await _context.cojBISWorkBudgetItems.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBISWorkBudgetItem.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetItem);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkBudgetItems/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetItem>>> GetAll () {
            
            try
            {
                var _cojBISWorkBudgetItem = await _context.cojBISWorkBudgetItems.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBISWorkBudgetItem.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/v1/cojBISWorkBudgetItems/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetItem>>> GetHistory (long id) {
            
            try
            {
                var _cojBISWorkBudgetItem = await _context.cojBISWorkBudgetItems.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBISWorkBudgetItem.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBISWorkBudgetItems/fy/2561
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetItem>>> fy (long fy) {


            try
            {
                var _cojBISWorkBudgetItem = await _context.cojBISWorkBudgetItems.Where (x => x.endDate == "31/12/9999 00:00:00" && x.fy==fy).OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBISWorkBudgetItem.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetItem);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkBudgetItems/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISWorkBudgetItem>>> searchName(string term)
        {
            
            try
            {
                var _cojBISWorkBudgetItem = await _context.cojBISWorkBudgetItems.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBISWorkBudgetItem.Count != 0)
                {
                    return Ok(_cojBISWorkBudgetItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISWorkBudgetItems/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBISWorkBudgetItem>> GetItem (long id) {

            try
            {
                var cojBISWorkBudgetItem = await _context.cojBISWorkBudgetItems.FindAsync (id);
                
                if (cojBISWorkBudgetItem == null) {

                    return NoContent ();

                }

                    return Ok(cojBISWorkBudgetItem);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojBISWorkBudgetItems
        [HttpPost]
        public async Task<ActionResult<cojBISWorkBudgetItem>> CreateItem (cojBISWorkBudgetItem newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBISWorkBudgetItems.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBISWorkBudgetItems.FindAsync (newItem.id);
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

        // PUT: api/v1/cojBISWorkBudgetItems/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBISWorkBudgetItem item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBISWorkBudgetItems.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBISWorkBudgetItems.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00" && a.fy==item.fy).ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBISWorkBudgetItems.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBISWorkBudgetItem _itemNew = new cojBISWorkBudgetItem {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    perentId = item.perentId,
                    cojWorkId = item.cojWorkId,
                    cojWorkActivityId =item.cojWorkActivityId,
                    cojWorkSubActivityId = item.cojWorkSubActivityId,
                    cojWorkBudgetTypeId = item.cojWorkBudgetTypeId,
                    cojWorkBudgetObjId = item.cojWorkBudgetObjId,
                    fy=item.fy,
                    budgetType = item.budgetType,
                    budgetObj = item.budgetObj,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBISWorkBudgetItems.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojBISWorkBudgetItemss/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBISWorkBudgetItems.FindAsync (id);

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