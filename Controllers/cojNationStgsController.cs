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
    public class cojNationStgsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojNationStgsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojNationStgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationStg>>> GetAllItem () {


            try
            {
                var _cojNationStg = await _context.cojNationStgs.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojNationStg.Count != 0)
                {
                    return Ok(_cojNationStg);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationStgs/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationStg>>> GetAll () {
            
            try
            {
                var _cojNationStg = await _context.cojNationStgs.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojNationStg.Count != 0)
                {
                    return Ok(_cojNationStg);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationStgs/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationStg>>> GetHistory (long id) {
            
            try
            {
                var _cojNationStg = await _context.cojNationStgs.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojNationStg.Count != 0)
                {
                    return Ok(_cojNationStg);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojNationStgs/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojNationStg>>> searchName(string term)
        {
            
            try
            {
                var _cojNationStg = await _context.cojNationStgs.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojNationStg.Count != 0)
                {
                    return Ok(_cojNationStg);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojNationStgs/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojNationStg>> GetItem (long id) {

            try
            {
                var cojNationStg = await _context.cojNationStgs.FindAsync (id);
                
                if (cojNationStg == null) {

                    return NoContent ();

                }

                    return Ok(cojNationStg);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojNationStgs
        [HttpPost]
        public async Task<ActionResult<cojNationStg>> CreateItem (cojNationStg newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojNationStgs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojNationStgs.FindAsync (newItem.id);
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

        // PUT: api/v1/cojNationStgs/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojNationStg item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojNationStgs.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojNationStgs.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojNationStgs.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojNationStg _itemNew = new cojNationStg {
                    idRef = item.idRef,
                    name = item.name,
                    vision = item.vision,
                    cojNationStgStartDate = item.cojNationStgStartDate,
                    cojNationStgEndDate = item.cojNationStgEndDate
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojNationStgs.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojNationStgs/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojNationStgs.FindAsync (id);

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