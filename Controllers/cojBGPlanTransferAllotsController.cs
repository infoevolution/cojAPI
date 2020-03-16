using System.IO.Compression;
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
    public class cojBGPlanTransferAllotsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanTransferAllotsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanTransferAllot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> GetAllItem () {


            try
            {
                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanTransferAllot/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> GetAll () {
            
            try
            {
                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanTransferAllot/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanTransferAllot/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanTransferAllot/bgPlan
        [Route("[action]/{bgPlanId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> bgPlan(double bgPlanId)
        {
            
            try
            {
                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.Where(x => x.cojBGPlanId==bgPlanId).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanTransferAllot/bgPlan
        [Route("[action]/{bgPlanId}/{cojWorkplanTypeId}/{cojBGWorkplanId}/{cojWorkActivityId}/{cojBudgetType}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> ActivityAllot(double bgPlanId, double cojWorkplanTypeId, double cojBGWorkplanId, double cojWorkActivityId, double cojBudgetType)
        {
            
            try
            {
                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.Where(x => x.cojBGPlanId==bgPlanId &&
                    x.cojWorkplanTypeId==cojWorkplanTypeId &&
                    x.cojBGWorkplanId==cojBGWorkplanId &&
                    x.cojWorkActivityId==cojWorkActivityId &&
                    x.cojBudgetType==cojBudgetType &&
                    x.endDate == "31/12/9999 00:00:00").OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanTransferAllot/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanTransferAllot>> GetItem (long id) {

            try
            {
                var cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.FindAsync (id);
                
                if (cojBGPlanTransferAllot == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanTransferAllot);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanTransferAllot
        [HttpPost]
        public async Task<ActionResult<cojBGPlanTransferAllot>> CreateItem (cojBGPlanTransferAllot newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanTransferAllots.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanTransferAllots.FindAsync (newItem.id);
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

        [Route("[action]")]  // POST MORE Row: api/cojBGPlanTransferAllot/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> UploadItem (cojBGPlanTransferAllot[] newItems) {
            
            try
            {
                foreach (var _itm in newItems) {

                    cojBGPlanTransferAllot newItem = new cojBGPlanTransferAllot {
                    idRef = 0,
                    name = _itm.name,
                    code = _itm.code,
                    cojBGPlanId = _itm.cojBGPlanId,
                    cojWorkplanTypeId = _itm.cojWorkplanTypeId,
                    cojBGWorkplanId = _itm.cojBGWorkplanId,
                    cojWorkActivityId = _itm.cojWorkActivityId,
                    cojAgencyId = _itm.cojAgencyId,
                    cojAgencyType = _itm.cojAgencyType,
                    cojBudgetType = _itm.cojBudgetType,
                    cojBGPlanQ1 = _itm.cojBGPlanQ1,
                    cojBGPlanQ2 = _itm.cojBGPlanQ2,
                    cojBGPlanQ3 = _itm.cojBGPlanQ3,
                    cojBGPlanQ4 = _itm.cojBGPlanQ4,
                    cojBGExtraQ1 = _itm.cojBGExtraQ1,
                    cojBGExtraQ2 = _itm.cojBGExtraQ2,
                    cojBGExtraQ3 = _itm.cojBGExtraQ3,
                    cojBGExtraQ4 = _itm.cojBGExtraQ4,
                    isRegionReserve = _itm.isRegionReserve,
                    remark = _itm.remark
                    // startDate = "",
                    // endDate = ""
                    };
                    
                    _context.cojBGPlanTransferAllots.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojBGPlanTransferAllots.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);                
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }

                return NoContent();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("[action]")]  // POST MORE Row: api/cojBGPlanTransferAllot/ReplaceItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGPlanTransferAllot>>> ReplaceItem (cojBGPlanTransferAllot[] newItems) {
            
            try
            {
                foreach (var _itm in newItems) {

                    // var _items = await _context.cojBGPlanTransferAllots.Where (a => a.cojBGPlanId == _itm.cojBGPlanId && 
                    // a.cojWorkplanTypeId ==_itm.cojWorkplanTypeId && 
                    // a.cojBGWorkplanId == _itm.cojBGWorkplanId && 
                    // a.cojWorkActivityId == _itm.cojWorkActivityId &&
                    // a.cojAgencyId == _itm.cojAgencyId &&
                    // a.cojBudgetType == _itm.cojBudgetType &&
                    // a.isRegionReserve == _itm.isRegionReserve &&
                    // a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                    // foreach (var _i in _items) {
                    //     var _x = await _context.cojBGPlanTransferAllots.FindAsync (_i.id);
                    //     _x.endDate = DateTime.Now.ToString (_culture);
                    //     _context.Entry (_x).State = EntityState.Modified;
                    //     await _context.SaveChangesAsync ();
                    // }

                    cojBGPlanTransferAllot newItem = new cojBGPlanTransferAllot {
                    idRef = 0,
                    name = _itm.name,
                    code = _itm.code,
                    cojBGPlanId = _itm.cojBGPlanId,
                    cojWorkplanTypeId = _itm.cojWorkplanTypeId,
                    cojBGWorkplanId = _itm.cojBGWorkplanId,
                    cojWorkActivityId = _itm.cojWorkActivityId,
                    cojAgencyId = _itm.cojAgencyId,
                    cojAgencyType = _itm.cojAgencyType,
                    cojBudgetType = _itm.cojBudgetType,
                    cojBGPlanQ1 = _itm.cojBGPlanQ1,
                    cojBGPlanQ2 = _itm.cojBGPlanQ2,
                    cojBGPlanQ3 = _itm.cojBGPlanQ3,
                    cojBGPlanQ4 = _itm.cojBGPlanQ4,
                    cojBGExtraQ1 = _itm.cojBGExtraQ1,
                    cojBGExtraQ2 = _itm.cojBGExtraQ2,
                    cojBGExtraQ3 = _itm.cojBGExtraQ3,
                    cojBGExtraQ4 = _itm.cojBGExtraQ4,
                    isRegionReserve = _itm.isRegionReserve,
                    remark = _itm.remark
                    // startDate = "",
                    // endDate = ""
                    };
                    
                    _context.cojBGPlanTransferAllots.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojBGPlanTransferAllots.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);                
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojBGPlanTransferAllot = await _context.cojBGPlanTransferAllots.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanTransferAllot.Count != 0)
                {
                    return Ok(_cojBGPlanTransferAllot);
                }

                return NoContent();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojBGPlanTransferAllot/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanTransferAllot item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanTransferAllots.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanTransferAllots.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanTransferAllots.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanTransferAllot _itemNew = new cojBGPlanTransferAllot {
                    idRef = item.idRef,
                    name = item.name,
                    code = item.code,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojAgencyId = item.cojAgencyId,
                    cojAgencyType = item.cojAgencyType,
                    cojBudgetType = item.cojBudgetType,
                    cojBGPlanQ1 = item.cojBGPlanQ1,
                    cojBGPlanQ2 = item.cojBGPlanQ2,
                    cojBGPlanQ3 = item.cojBGPlanQ3,
                    cojBGPlanQ4 = item.cojBGPlanQ4,
                    cojBGExtraQ1 = item.cojBGExtraQ1,
                    cojBGExtraQ2 = item.cojBGExtraQ2,
                    cojBGExtraQ3 = item.cojBGExtraQ3,
                    cojBGExtraQ4 = item.cojBGExtraQ4,
                    isRegionReserve = item.isRegionReserve,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanTransferAllots.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanTransferAllot/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanTransferAllots.FindAsync (id);

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