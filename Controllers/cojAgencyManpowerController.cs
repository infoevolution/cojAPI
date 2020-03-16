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
    public class cojAgencyManpowerController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojAgencyManpowerController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojAgencyManpower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyManpower>>> GetAllItem () {
            try
            {
                var _cojAgencyManpower = await _context.cojAgencyManpowers.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojAgencyManpower.Count != 0)
                {
                    return Ok(_cojAgencyManpower);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyManpower/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyManpower>>> GetAll () {
           try
           {
               var _cojAgencyManpower = await _context.cojAgencyManpowers.OrderBy (a => a.idRef).ToListAsync ();

               if(_cojAgencyManpower.Count != 0)
               {
                   return Ok(_cojAgencyManpower);
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyManpower/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyManpower>>> GetHistory (long id) {
            
            try
            {
                var _cojAgencyManpower = await _context.cojAgencyManpowers.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojAgencyManpower.Count != 0)
                {
                    return Ok(_cojAgencyManpower);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyManpower/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojAgencyManpower>> GetItem (long id) {
            var cojAgencyManpower = await _context.cojAgencyManpowers.FindAsync (id);

            try
            {
                if (cojAgencyManpower == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyManpower);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyManpower/1
        // where ตาม cojAgency
        [HttpGet ("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<cojAgencyManpower>>> cojAgency (long id) {

            var cojAgencyManpower = await _context.cojAgencyManpowers.Where(x => x.cojAgencyId == id && x.endDate == "31/12/9999 00:00:00").ToListAsync();
            try
            {
                if (cojAgencyManpower == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyManpower);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojAgencyManpower
        [HttpPost]
        public async Task<ActionResult<cojAgencyManpower>> CreateItem (cojAgencyManpower newItem) {
            
            //check duplicate item id, code, name
            //...
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }

                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojAgencyManpowers.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojAgencyManpowers.FindAsync (newItem.id);
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

        // PUT: api/cojAgencyManpower/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojAgencyManpower item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojAgencyManpowers.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojAgencyManpowers.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojAgencyManpowers.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojAgencyManpower _itemNew = new cojAgencyManpower {
                    idRef = item.idRef,
                    cojAgencyId = item.cojAgencyId,
                    cojPositionType = item.cojPositionType,
                    cojPosition = item.cojPosition,
                    cojPositionCeiling = item.cojPositionCeiling,
                    cojPositionOnhand = item.cojPositionOnhand,
                    remark = item.remark                  
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojAgencyManpowers.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojAgencyManpower/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojAgencyManpowers.FindAsync (id);

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