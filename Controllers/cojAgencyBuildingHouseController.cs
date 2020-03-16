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
    public class cojAgencyBuildingHouseController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojAgencyBuildingHouseController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojAgencyBuildingHouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingHouse>>> GetAllItem () {
            try
            {
                var _cojAgencyBuildingHouse = await _context.cojAgencyBuildingHouses.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojAgencyBuildingHouse.Count != 0)
                {
                    return Ok(_cojAgencyBuildingHouse);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingHouse/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingHouse>>> GetAll () {
           try
           {
               var _cojAgencyBuildingHouse = await _context.cojAgencyBuildingHouses.OrderBy (a => a.idRef).ToListAsync ();

               if(_cojAgencyBuildingHouse.Count != 0)
               {
                   return Ok(_cojAgencyBuildingHouse);
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingHouse/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingHouse>>> GetHistory (long id) {
            
            try
            {
                var _cojAgencyBuildingHouse = await _context.cojAgencyBuildingHouses.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojAgencyBuildingHouse.Count != 0)
                {
                    return Ok(_cojAgencyBuildingHouse);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingHouse/searchName
        // [Route("[action]/{term}")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<cojAgencyBuildingHouse>>> searchName(string term)
        // {
            
        //     try
        //     {
        //         var _cojAgecnyBuildingHouse = await _context.cojAgencyBuildingHouses.Where(x => x.remark.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

        //         if(_cojAgecnyBuildingHouse.Count != 0)
        //         {
        //             return _cojAgecnyBuildingHouse;
        //         }
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
            
        // }

        // GET: api/cojAgencyBuildingHouse/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojAgencyBuildingHouse>> GetItem (long id) {
            var cojAgencyBuildingHouse = await _context.cojAgencyBuildingHouses.FindAsync (id);

            try
            {
                if (cojAgencyBuildingHouse == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuildingHouse);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingHouse/1
        // where ตาม cojAgency
        [HttpGet ("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingHouse>>> cojAgencyBuilding (long id) {

            var cojAgencyBuildingHouse = await _context.cojAgencyBuildingHouses.Where(x => x.cojAgencyBuildingId == id && x.endDate == "31/12/9999 00:00:00").ToListAsync();

            try
            {
                if (cojAgencyBuildingHouse == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuildingHouse);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojAgencyBuildingHouse
        [HttpPost]
        public async Task<ActionResult<cojAgencyBuildingHouse>> CreateItem (cojAgencyBuildingHouse newItem) {


            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojAgencyBuildingHouses.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojAgencyBuildingHouses.FindAsync (newItem.id);
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

        // PUT: api/cojAgencyBuildingHouse/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojAgencyBuildingHouse item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojAgencyBuildingHouses.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojAgencyBuildingHouses.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojAgencyBuildingHouses.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojAgencyBuildingHouse _itemNew = new cojAgencyBuildingHouse {
                    idRef = item.idRef,
                    cojAgencyBuildingId = item.cojAgencyBuildingId,
                    cojHousePosition = item.cojHousePosition,
                    cojHousePositionUnit = item.cojHousePositionUnit
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojAgencyBuildingHouses.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojAgencyBuildingHouse/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojAgencyBuildingHouses.FindAsync (id);

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