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
    public class cojAgencyBuildingCondoController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojAgencyBuildingCondoController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojAgencyBuildingCondo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingCondo>>> GetAllItem () {
            try
            {
                var _cojAgencyBuildingCondo = await _context.cojAgencyBuildingCondos.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojAgencyBuildingCondo.Count != 0)
                {
                    return Ok(_cojAgencyBuildingCondo);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingCondo/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingCondo>>> GetAll () {
           try
           {
               var _cojAgencyBuildingCondo = await _context.cojAgencyBuildingCondos.OrderBy (a => a.idRef).ToListAsync ();

               if(_cojAgencyBuildingCondo.Count != 0)
               {
                   return Ok(_cojAgencyBuildingCondo);
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingCondo/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingCondo>>> GetHistory (long id) {
            
            try
            {
                var _cojAgencyBuildingCondo = await _context.cojAgencyBuildingCondos.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojAgencyBuildingCondo.Count != 0)
                {
                    return Ok(_cojAgencyBuildingCondo);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/cojAgencyBuildingCondo/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojAgencyBuildingCondo>> GetItem (long id) {
            var cojAgencyBuildingCondo = await _context.cojAgencyBuildingCondos.FindAsync (id);

            try
            {
                if (cojAgencyBuildingCondo == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuildingCondo);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuildingCondo/1
        // where ตาม cojAgency
        [HttpGet ("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<cojAgencyBuildingCondo>>> cojAgencyBuilding (long id) {

            var cojAgencyBuildingCondo = await _context.cojAgencyBuildingCondos.Where(x => x.cojAgencyBuildingId == id && x.endDate == "31/12/9999 00:00:00").ToListAsync();

            try
            {
                if (cojAgencyBuildingCondo == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuildingCondo);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojAgencyBuildingCondo
        [HttpPost]
        public async Task<ActionResult<cojAgencyBuildingCondo>> CreateItem (cojAgencyBuildingCondo newItem) {


            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojAgencyBuildingCondos.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);

            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cojAgencyBuildingCondo/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojAgencyBuildingCondo item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }


                //Add new
                cojAgencyBuildingCondo _itemNew = new cojAgencyBuildingCondo {
                    idRef = item.idRef,
                    cojAgencyBuildingId = item.cojAgencyBuildingId,
                    cojCondoUnit = item.cojCondoUnit,
                    cojCondoBuilding = item.cojCondoBuilding
                };

                _context.cojAgencyBuildingCondos.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojAgencyBuildingCondo/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojAgencyBuildingCondos.FindAsync (id);

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