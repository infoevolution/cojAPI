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
    public class cojBGPlanWorkplanActivitysController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplanActivitysController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanWorkplanActivity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivity>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplanActivity = await _context.cojBGPlanWorkplanActivities.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplanActivity.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivity);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanWorkplanActivity/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivity>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplanActivity = await _context.cojBGPlanWorkplanActivities.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplanActivity.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivity);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivity/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivity>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplanActivity = await _context.cojBGPlanWorkplanActivities.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplanActivity.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivity);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplanActivity/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplanActivity>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanWorkplanActivity = await _context.cojBGPlanWorkplanActivities.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanWorkplanActivity.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplanActivity);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanWorkplanActivity/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplanActivity>> GetItem (long id) {

            try
            {
                var cojBGPlanWorkplanActivity = await _context.cojBGPlanWorkplanActivities.FindAsync (id);
                
                if (cojBGPlanWorkplanActivity == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanWorkplanActivity);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanWorkplanActivity
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplanActivity>> CreateItem (cojBGPlanWorkplanActivity newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanWorkplanActivities.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplanActivities.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanWorkplanActivity/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplanActivity item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanWorkplanActivities.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanWorkplanActivities.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplanActivities.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanWorkplanActivity _itemNew = new cojBGPlanWorkplanActivity {
                    idRef = item.idRef,
                    name = item.name,
                    code = item.code,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojBGPlanSumA = item.cojBGPlanSumA,
                    cojBGPlanSumB = item.cojBGPlanSumB,
                    cojBGPlanSumC = item.cojBGPlanSumC,
                    cojBGPlanSumAMT = item.cojBGPlanSumAMT,
                    cojBGPlanTotalAMT = item.cojBGPlanTotalAMT,
                    cojBGPlanTotalAMTShow = item.cojBGPlanTotalAMTShow,
                    cojAgencys = item.cojAgencys,
                    cojAgencysFulltext = item.cojAgencysFulltext,
                    remark = item.remark,
                    procumentAgency = item.procumentAgency,
                    disbursementAgency = item.disbursementAgency,
                    responsibilityAgency = item.responsibilityAgency
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanWorkplanActivities.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanWorkplanActivity/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplanActivities.FindAsync (id);

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