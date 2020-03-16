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
    public class cojRegionReserveExtrasController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRegionReserveExtrasController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojRegionReserveExtras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveExtra>>> GetAllItem () {


            try
            {
                var _cojRegionReserveExtra = await _context.cojRegionReserveExtras.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojRegionReserveExtra.Count != 0)
                {
                    return Ok(_cojRegionReserveExtra);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojRegionReserveExtras/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveExtra>>> GetAll () {
            
            try
            {
                var _cojRegionReserveExtra = await _context.cojRegionReserveExtras.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojRegionReserveExtra.Count != 0)
                {
                    return Ok(_cojRegionReserveExtra);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRegionReserveExtras/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveExtra>>> GetHistory (long id) {
            
            try
            {
                var _cojRegionReserveExtra = await _context.cojRegionReserveExtras.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojRegionReserveExtra.Count != 0)
                {
                    return Ok(_cojRegionReserveExtra);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojRegionReserveExtras/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojRegionReserveExtra>>> searchName(string term)
        {
            
            try
            {
                var _cojRegionReserveExtra = await _context.cojRegionReserveExtras.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojRegionReserveExtra.Count != 0)
                {
                    return Ok(_cojRegionReserveExtra);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojRegionReserveExtras/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojRegionReserveExtra>> GetItem (long id) {

            try
            {
                var cojRegionReserveExtra = await _context.cojRegionReserveExtras.FindAsync (id);
                
                if (cojRegionReserveExtra == null) {

                    return NoContent ();

                }

                    return Ok(cojRegionReserveExtra);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojRegionReserveExtras
        [HttpPost]
        public async Task<ActionResult<cojRegionReserveExtra>> CreateItem (cojRegionReserveExtra newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojRegionReserveExtras.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojRegionReserveExtras.FindAsync (newItem.id);
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

        [Route("[action]")]  // POST: api/cojRegionReserveExtra/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojRegionReserveExtra>>> UploadItem (cojRegionReserveExtra[] newItems) {
            
            try
            {
                foreach (var _itm in newItems) {

                    cojRegionReserveExtra newItem = new cojRegionReserveExtra {
                    idRef = 0,
                    name  = _itm.name,
                    cojAgencyId = _itm.cojAgencyId ,
                    cojBGPlanId = _itm.cojBGPlanId ,
                    cojWorkplanTypeId = _itm.cojWorkplanTypeId ,
                    cojBGWorkplanId = _itm.cojBGWorkplanId ,
                    cojWorkActivityId = _itm.cojWorkActivityId,
                    cojWorkActivityItemId = _itm.cojWorkActivityItemId,
                    cojRegionReserveExtraQ1 = _itm.cojRegionReserveExtraQ1,
                    cojRegionReserveExtraQ2 = _itm.cojRegionReserveExtraQ2,
                    cojRegionReserveExtraQ3 = _itm.cojRegionReserveExtraQ3,
                    cojRegionReserveExtraQ4 = _itm.cojRegionReserveExtraQ4,
                    // startDate = "",
                    // endDate = ""
                    };
                    
                    newItem.startDate = DateTime.Now.ToString (_culture);
                    newItem.endDate = "31/12/9999 00:00:00";    

                    _context.cojRegionReserveExtras.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojRegionReserveExtras.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);                
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojRegionReserveAllot = await _context.cojRegionReserveExtras.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
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

        // PUT: api/cojRegionReserveExtras/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojRegionReserveExtra item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                // var _items = await _context.cojRegionReserveExtras.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojRegionReserveExtras.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojRegionReserveExtra _itemNew = new cojRegionReserveExtra {
                    idRef = item.idRef,
                    name  = item.name,
                    cojAgencyId = item.cojAgencyId ,
                    cojBGPlanId = item.cojBGPlanId ,
                    cojWorkplanTypeId = item.cojWorkplanTypeId ,
                    cojBGWorkplanId = item.cojBGWorkplanId ,
                    cojWorkActivityId = item.cojWorkActivityId,
                    cojWorkActivityItemId = item.cojWorkActivityItemId,
                    cojRegionReserveExtraQ1 = item.cojRegionReserveExtraQ1,
                    cojRegionReserveExtraQ2 = item.cojRegionReserveExtraQ2,
                    cojRegionReserveExtraQ3 = item.cojRegionReserveExtraQ3,
                    cojRegionReserveExtraQ4 = item.cojRegionReserveExtraQ4
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojRegionReserveExtras.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojRegionReserveExtras/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojRegionReserveExtras.FindAsync (id);

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