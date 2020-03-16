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
    public class cojBGPlanWorkplanActivityItemsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplanActivityItemsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanWorkplanActivityItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityItem>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplanActivityItem = await _context.cojBGPlanWorkplanActivityItems.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplanActivityItem.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityItem);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanWorkplanActivityItem/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityItem>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplanActivityItem = await _context.cojBGPlanWorkplanActivityItems.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplanActivityItem.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivityItem/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityItem>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplanActivityItem = await _context.cojBGPlanWorkplanActivityItems.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplanActivityItem.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivityItem/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivityItem>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanWorkplanActivityItem = await _context.cojBGPlanWorkplanActivityItems.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanWorkplanActivityItem.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivityItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanWorkplanActivityItem/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplanActivityItem>> GetItem (long id) {

            try
            {
                var cojBGPlanWorkplanActivityItem = await _context.cojBGPlanWorkplanActivityItems.FindAsync (id);
                
                if (cojBGPlanWorkplanActivityItem == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanWorkplanActivityItem);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanWorkplanActivityItem
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplanActivityItem>> CreateItem (cojBGPlanWorkplanActivityItem newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //

                // newItem.startDate = DateTime.Now.ToString (_culture);   
                // newItem.endDate = "31/12/9999 00:00:00";
                
               newItem.startDate = DateTime.Now.ToString (_culture);                
               newItem.endDate = "31/12/9999 00:00:00";
                _context.cojBGPlanWorkplanActivityItems.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplanActivityItems.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanWorkplanActivityItem/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplanActivityItem item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanWorkplanActivityItems.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanWorkplanActivityItems.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplanActivityItems.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanWorkplanActivityItem _itemNew = new cojBGPlanWorkplanActivityItem {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojWorkActivityItemId = item.cojWorkActivityItemId,
                    quantityUnit = item.quantityUnit,
                    quantityUnitName = item.quantityUnitName,
                    periodStart = item.periodStart,
                    periodEnd = item.periodEnd,
                    budgetTypeId = item.budgetTypeId,
                    budgetAmount = item.budgetAmount,
                    cojBGWorkplanActivityItemParentId = item.cojBGWorkplanActivityItemParentId,
                    cojBGWorkplanActivityItemLevel = item.cojBGWorkplanActivityItemLevel,
                    cojAgencys = item.cojAgencys,
                    showInSummary = item.showInSummary,
                    remark = item.remark,
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00",
                    procumentAgency = item.procumentAgency,
                    disbursementAgency = item.disbursementAgency,
                    responsibilityAgency = item.responsibilityAgency
                };

                _context.cojBGPlanWorkplanActivityItems.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanWorkplanActivityItem/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplanActivityItems.FindAsync (id);

            try
            {
                if (_item == null) {
                    return NoContent ();
                }

                //update endDate
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