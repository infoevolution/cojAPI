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
    public class cojAgencyBuildingOptionController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojAgencyBuildingOptionController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojAgencyBuildingOption
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingOption>>> GetAllItem () {
            try
            {
                var _cojAgencyBuildingOption = await _context.cojAgencyBuildingOptions.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojAgencyBuildingOption.Count != 0)
                {
                    return Ok(_cojAgencyBuildingOption);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingOption/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingOption>>> GetAll () {
           try
           {
               var _cojAgencyBuildingOption = await _context.cojAgencyBuildingOptions.OrderBy (a => a.idRef).ToListAsync ();

               if(_cojAgencyBuildingOption.Count != 0)
               {
                   return Ok(_cojAgencyBuildingOption);
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingOption/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingOption>>> GetHistory (long id) {
            
            try
            {
                var _cojAgencyBuildingOption = await _context.cojAgencyBuildingOptions.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojAgencyBuildingOption.Count != 0)
                {
                    return Ok(_cojAgencyBuildingOption);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingOption/searchName
        // [Route("[action]/{term}")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<cojAgencyBuildingOption>>> searchName(string term)
        // {
            
        //     try
        //     {
        //         var _cojAgecnyBuildingOption = await _context.cojAgencyBuildingOptions.Where(x => x.remark.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

        //         if(_cojAgecnyBuildingOption.Count != 0)
        //         {
        //             return _cojAgecnyBuildingOption;
        //         }
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
            
        // }

        // GET: api/cojAgencyBuildingOption/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojAgencyBuildingOption>> GetItem (long id) {
            var cojAgencyBuildingOption = await _context.cojAgencyBuildingOptions.FindAsync (id);

            try
            {
                if (cojAgencyBuildingOption == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuildingOption);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingOption/1
        // where ตาม cojAgencyBuilding
        [HttpGet ("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingOption>>> cojAgencyBuilding (long id) {

            var cojAgencyBuildingOption = await _context.cojAgencyBuildingOptions.Where(x => x.cojAgencyBuildingId == id && x.endDate == "31/12/9999 00:00:00").ToListAsync();

            try
            {
                if (cojAgencyBuildingOption == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuildingOption);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojAgencyBuildingOption
        [HttpPost]
        public async Task<ActionResult<cojAgencyBuildingOption>> CreateItem (cojAgencyBuildingOption newItem) {


            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";
                
                _context.cojAgencyBuildingOptions.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;
                
                //initial new item
                // var _item = await _context.cojAgencyBuildingOptions.FindAsync (newItem.id);
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

        // PUT: api/cojAgencyBuildingOption/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojAgencyBuildingOption item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojAgencyBuildingOptions.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojAgencyBuildingOptions.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojAgencyBuildingOptions.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojAgencyBuildingOption _itemNew = new cojAgencyBuildingOption {
                    idRef = item.idRef,
                    cojAgencyBuildingId = item.cojAgencyBuildingId,
                    cojAreaIndorOther = item.cojAreaIndorOther,
                    cojAreaIndorOtherRoom = item.cojAreaIndorOtherRoom,
                    cojAreaIndorOtherSize = item.cojAreaIndorOtherSize
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojAgencyBuildingOptions.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojAgencyBuildingOption/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojAgencyBuildingOptions.FindAsync (id);

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