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
    public class cojAccountBookController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojAccountBookController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojAccountBook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAccountBook>>> GetAllItem () {
            try
            {
                return await _context.cojAccountBooks.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAccountBook/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAccountBook>>> GetAll () {
           try
           {
               return await _context.cojAccountBooks.OrderBy (a => a.idRef).ToListAsync ();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAccountBook/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAccountBook>>> GetHistory (long id) {
            
            try
            {
                return await _context.cojAccountBooks.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAccountBook/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAccountBook>>> searchName(string term)
        {
            
            try
            {
                return await _context.cojAccountBooks.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojAccountBook/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojAccountBook>> GetItem (long id) {
            var cojAccountBook = await _context.cojAccountBooks.FindAsync (id);

            try
            {
                if (cojAccountBook == null) {
                    return NoContent ();
                }

                return cojAccountBook;
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuilding/1
        // where ตาม cojAgency
        [HttpGet ("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<cojAccountBook>>> cojAgency (long id) {

            var cojAccountBook = await _context.cojAccountBooks.Where(x => x.cojAgencyId == id && x.endDate == "31/12/9999 00:00:00").ToListAsync();

            try
            {
                //if (cojAccountBook == null || cojAccountBook.Count == 0) 
                if (cojAccountBook == null ) 
                {
                    return NoContent ();
                }

                return Ok(cojAccountBook);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojAccountBook
        [HttpPost]
        public async Task<ActionResult<cojAccountBook>> CreateItem (cojAccountBook newItem) {
            
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
                
                _context.cojAccountBooks.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojAccountBooks.FindAsync (newItem.id);
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

        // PUT: api/cojAccountBook/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojAccountBook item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojAccountBooks.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojAccountBooks.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojAccountBooks.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojAccountBook _itemNew = new cojAccountBook {
                    idRef = item.idRef,
                    cojAgencyId = item.cojAgencyId,
                    status = item.status,
                    //itemSort = item.itemSort,
                    code = item.code,
                    name = item.name,
                    bank = item.bank,
                    accountType = item.accountType,
                    fund = item.fund,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojAccountBooks.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojAccountBook/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojAccountBooks.FindAsync (id);

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