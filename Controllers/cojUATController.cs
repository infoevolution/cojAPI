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
    public class cojUATController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojUATController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojUAT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUAT>>> GetAllItem () {


            try
            {
                var _cojUAT = await _context.cojUATs.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojUAT.Count != 0)
                {
                    return Ok(_cojUAT);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojUAT/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUAT>>> GetAll () {
            
            try
            {
                var _cojUAT = await _context.cojUATs.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojUAT.Count != 0)
                {
                    return Ok(_cojUAT);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojUAT/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUAT>>> GetHistory (long id) {
            
            try
            {
                var _cojUAT = await _context.cojUATs.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojUAT.Count != 0)
                {
                    return Ok(_cojUAT);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojUAT/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUAT>>> searchName(string term)
        {
            
            try
            {
                var _cojUAT = await _context.cojUATs.Where(x => x.uatName.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojUAT.Count != 0)
                {
                    return Ok(_cojUAT);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojUAT/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojUAT>> GetItem (long id) {

            try
            {
                var cojUAT = await _context.cojUATs.FindAsync (id);
                
                if (cojUAT == null) {

                    return NoContent ();

                }

                    return Ok(cojUAT);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojUAT
        [HttpPost]
        public async Task<ActionResult<cojUAT>> CreateItem (cojUAT newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojUATs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojUATs.FindAsync (newItem.id);
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

        // PUT: api/cojUAT/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojUAT item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojUATs.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojUATs.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojUATs.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojUAT _itemNew = new cojUAT {
                    idRef = item.idRef,
                    uatNo = item.uatNo,
                    uatCode = item.uatCode,
                    uatDate = item.uatDate,
                    uatNote = item.uatNote,
                    uatResult = item.uatResult,
                    uatTester = item.uatTester,
                    cojApp = item.cojApp,
                    cojCmd = item.cojCmd
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojUATs.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojUAT/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojUATs.FindAsync (id);

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