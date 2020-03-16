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
    public class cojRegionReserveActivityItemsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRegionReserveActivityItemsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojRegionReserveActivityItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveActivityItem>>> GetAllItem () {


            try
            {
                var _cojRegionReserveActivityItem = await _context.cojRegionReserveActivityItems.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojRegionReserveActivityItem.Count != 0)
                {
                    return Ok(_cojRegionReserveActivityItem);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojRegionReserveActivityItems/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveActivityItem>>> GetAll () {
            
            try
            {
                var _cojRegionReserveActivityItem = await _context.cojRegionReserveActivityItems.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojRegionReserveActivityItem.Count != 0)
                {
                    return Ok(_cojRegionReserveActivityItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRegionReserveActivityItems/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveActivityItem>>> GetHistory (long id) {
            
            try
            {
                var _cojRegionReserveActivityItem = await _context.cojRegionReserveActivityItems.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojRegionReserveActivityItem.Count != 0)
                {
                    return Ok(_cojRegionReserveActivityItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRegionReserveActivityItems/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveActivityItem>>> searchName(string term)
        {
            
            try
            {
                var _cojRegionReserveActivityItem = await _context.cojRegionReserveActivityItems.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojRegionReserveActivityItem.Count != 0)
                {
                    return Ok(_cojRegionReserveActivityItem);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojRegionReserveActivityItems/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojRegionReserveActivityItem>> GetItem (long id) {

            try
            {
                var cojRegionReserveActivityItem = await _context.cojRegionReserveActivityItems.FindAsync (id);
                
                if (cojRegionReserveActivityItem == null) {

                    return NoContent ();

                }

                    return Ok(cojRegionReserveActivityItem);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojRegionReserveActivityItems
        [HttpPost]
        public async Task<ActionResult<cojRegionReserveActivityItem>> CreateItem (cojRegionReserveActivityItem newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojRegionReserveActivityItems.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojRegionReserveActivityItems.FindAsync (newItem.id);
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

        [Route("[action]")]  // POST: api/cojRegionReserveActivityItem/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojRegionReserveActivityItem>>> UploadItem (cojRegionReserveActivityItem[] newItems) {
            
            try
            {
                foreach (var _itm in newItems) {

                    cojRegionReserveActivityItem newItem = new cojRegionReserveActivityItem {
                    idRef = 0,
                    code = _itm.code,
                    name  = _itm.name,
                    cojBGPlanId = _itm.cojBGPlanId ,
                    cojAgencyId = _itm.cojAgencyId ,
                    cojWorkplanTypeId = _itm.cojWorkplanTypeId ,
                    cojBGWorkplanId = _itm.cojBGWorkplanId ,
                    cojWorkActivityId = _itm.cojWorkActivityId ,
                    itemSort = _itm.itemSort ,
                    cojBudgetType = _itm.cojBudgetType,
                    cojItemType = _itm.cojItemType,
                    cojRegionReserveAMT = _itm.cojRegionReserveAMT ,
                    // startDate = "",
                    // endDate = ""
                    };
                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";
                    
                    _context.cojRegionReserveActivityItems.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojRegionReserveActivityItems.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);                
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojRegionReserveActivityItem = await _context.cojRegionReserveActivityItems.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojRegionReserveActivityItem.Count != 0)
                {
                    return Ok(_cojRegionReserveActivityItem);
                }

                return NoContent();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojRegionReserveActivityItems/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojRegionReserveActivityItem item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                // var _items = await _context.cojRegionReserveActivityItems.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojRegionReserveActivityItems.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojRegionReserveActivityItem _itemNew = new cojRegionReserveActivityItem {
                    idRef = item.idRef,
                    code = item.code,
                    name  = item.name,
                    cojBGPlanId = item.cojBGPlanId ,
                    cojAgencyId = item.cojAgencyId ,
                    cojWorkplanTypeId = item.cojWorkplanTypeId ,
                    cojBGWorkplanId = item.cojBGWorkplanId ,
                    cojWorkActivityId = item.cojWorkActivityId ,
                    itemSort = item.itemSort ,
                    cojBudgetType = item.cojBudgetType,
                    cojItemType = item.cojItemType,
                    cojRegionReserveAMT = item.cojRegionReserveAMT
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojRegionReserveActivityItems.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojRegionReserveActivityItems/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojRegionReserveActivityItems.FindAsync (id);

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