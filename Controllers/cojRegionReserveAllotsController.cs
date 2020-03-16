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
    public class cojRegionReserveAllotsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRegionReserveAllotsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojRegionReserveAllots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveAllot>>> GetAllItem () {


            try
            {
                var _cojRegionReserveAllot = await _context.cojRegionReserveAllots.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojRegionReserveAllot.Count != 0)
                {
                    return Ok(_cojRegionReserveAllot);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojRegionReserveAllots/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveAllot>>> GetAll () {
            
            try
            {
                var _cojRegionReserveAllot = await _context.cojRegionReserveAllots.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojRegionReserveAllot.Count != 0)
                {
                    return Ok(_cojRegionReserveAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRegionReserveAllots/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveAllot>>> GetHistory (long id) {
            
            try
            {
                var _cojRegionReserveAllot = await _context.cojRegionReserveAllots.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojRegionReserveAllot.Count != 0)
                {
                    return Ok(_cojRegionReserveAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRegionReserveAllots/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveAllot>>> searchName(string term)
        {
            
            try
            {
                var _cojRegionReserveAllot = await _context.cojRegionReserveAllots.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojRegionReserveAllot.Count != 0)
                {
                    return Ok(_cojRegionReserveAllot);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojRegionReserveAllots/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojRegionReserveAllot>> GetItem (long id) {

            try
            {
                var cojRegionReserveAllot = await _context.cojRegionReserveAllots.FindAsync (id);
                
                if (cojRegionReserveAllot == null) {

                    return NoContent ();

                }

                    return Ok(cojRegionReserveAllot);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojRegionReserveAllots
        [HttpPost]
        public async Task<ActionResult<cojRegionReserveAllot>> CreateItem (cojRegionReserveAllot newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojRegionReserveAllots.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojRegionReserveAllots.FindAsync (newItem.id);
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

        [Route("[action]")]  // POST: api/cojRegionReserveAllot/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojRegionReserveAllot>>> UploadItem (cojRegionReserveAllot[] newItems) {
            
            try
            {
                foreach (var _itm in newItems) {

                    cojRegionReserveAllot newItem = new cojRegionReserveAllot {
                    idRef = 0,
                    itemSort = _itm.itemSort,
                    code = _itm.code,
                    name  = _itm.name,
                    remark = _itm.remark ,
                    agencyType = _itm.agencyType ,
                    cojAgencyId = _itm.cojAgencyId ,
                    cojFund = _itm.cojFund ,
                    cojBGPlanId = _itm.cojBGPlanId ,
                    cojWorkplanTypeId = _itm.cojWorkplanTypeId ,
                    cojBGWorkplanId = _itm.cojBGWorkplanId ,
                    cojWorkActivityId = _itm.cojWorkActivityId,
                    cojWorkActivityItemId = _itm.cojWorkActivityItemId,
                    quantityUnit = _itm.quantityUnit,
                    quantityUnitName = _itm.quantityUnitName,
                    unitPrice = _itm.unitPrice,
                    cojRegionReserveAMT = _itm.cojRegionReserveAMT ,
                    cojRegionReserveAllotQ1 = _itm.cojRegionReserveAllotQ1,
                    cojRegionReserveAllotQ2 = _itm.cojRegionReserveAllotQ2,
                    cojRegionReserveAllotQ3 = _itm.cojRegionReserveAllotQ3,
                    cojRegionReserveAllotQ4 = _itm.cojRegionReserveAllotQ4,
                    cojAllotType = _itm.cojAllotType,
                    // startDate = "",
                    // endDate = ""
                    };
                    
                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";

                    _context.cojRegionReserveAllots.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojRegionReserveAllots.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);                
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojRegionReserveAllot = await _context.cojRegionReserveAllots.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojRegionReserveAllot.Count != 0)
                {
                    return Ok(_cojRegionReserveAllot);
                }

                return NoContent();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojRegionReserveAllots/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojRegionReserveAllot item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                // var _items = await _context.cojRegionReserveAllots.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojRegionReserveAllots.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojRegionReserveAllot _itemNew = new cojRegionReserveAllot {
                    idRef = item.idRef,
                    itemSort = item.itemSort,
                    code = item.code,
                    name  = item.name,
                    remark = item.remark ,
                    agencyType = item.agencyType ,
                    cojAgencyId = item.cojAgencyId ,
                    cojFund = item.cojFund ,
                    cojBGPlanId = item.cojBGPlanId ,
                    cojWorkplanTypeId = item.cojWorkplanTypeId ,
                    cojBGWorkplanId = item.cojBGWorkplanId ,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojWorkActivityItemId = item.cojWorkActivityItemId,
                    quantityUnit = item.quantityUnit,
                    quantityUnitName = item.quantityUnitName,
                    unitPrice = item.unitPrice,
                    cojRegionReserveAMT = item.cojRegionReserveAMT ,
                    cojRegionReserveAllotQ1 = item.cojRegionReserveAllotQ1,
                    cojRegionReserveAllotQ2 = item.cojRegionReserveAllotQ2,
                    cojRegionReserveAllotQ3 = item.cojRegionReserveAllotQ3,
                    cojRegionReserveAllotQ4 = item.cojRegionReserveAllotQ4,
                    cojAllotType = item.cojAllotType
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojRegionReserveAllots.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojRegionReserveAllots/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojRegionReserveAllots.FindAsync (id);

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