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
    public class cojBISLinkWorksController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBISLinkWorksController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISLinkWork>>> fy (int fy) {
            try
            {
                var _cojBISLinkWork = await _context.cojBISLinkWorks.Where (x => x.endDate == "31/12/9999 00:00:00" && x.fy==fy).OrderBy (a => a.idRef).ToListAsync ();
                if(_cojBISLinkWork.Count != 0)
                {
                    return Ok(_cojBISLinkWork);
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/v1/cojBISLinkWorks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISLinkWork>>> GetAllItem () {


            try
            {
                var _cojBISLinkWork = await _context.cojBISLinkWorks.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBISLinkWork.Count != 0)
                {
                    return Ok(_cojBISLinkWork);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojBISLinkWorks/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISLinkWork>>> GetAll () {
            
            try
            {
                var _cojBISLinkWork = await _context.cojBISLinkWorks.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBISLinkWork.Count != 0)
                {
                    return Ok(_cojBISLinkWork);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBISLinkWorks/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBISLinkWork>>> GetHistory (long id) {
            
            try
            {
                var _cojBISLinkWork = await _context.cojBISLinkWorks.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBISLinkWork.Count != 0)
                {
                    return Ok(_cojBISLinkWork);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojBISLinkWorks/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBISLinkWork>> GetItem (long id) {

            try
            {
                var cojBISLink = await _context.cojBISLinkWorks.FindAsync (id);
                
                if (cojBISLink == null) {

                    return NoContent ();

                }

                    return Ok(cojBISLink);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
            
        }

        // POST: api/v1/cojBISLinkWorks
        [HttpPost]
        public async Task<ActionResult<cojBISLinkWork>> CreateItem (cojBISLinkWork newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBISLinkWorks.Add(newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBISLinkWorks.FindAsync (newItem.id);
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

        // PUT: api/v1/cojBISLinkWorks/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBISLinkWork item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBISLinkWorks.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBISLinkWorks.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBISLinkWorks.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBISLinkWork _itemNew = new cojBISLinkWork {
                    idRef = item.idRef,
                    cojBISLinkId = item.cojBISLinkId,
                    cojStgId = item.cojStgId,
                    cojWorkId = item.cojWorkId,
                    fy = item.fy
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBISLinkWorks.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojBISLinkWorkss/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBISLinkWorks.FindAsync (id);

            try
            {
                if (_item == null) {
                    return NoContent ();
                }

                //update dateEnd
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