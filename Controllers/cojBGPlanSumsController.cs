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
    public class cojBGPlanSumsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanSumsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanSum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanSum>>> GetAllItem () {


            try
            {
                var _cojBGPlanSum = await _context.cojBGPlanSums.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanSum.Count != 0)
                {
                    return Ok(_cojBGPlanSum);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanSum/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanSum>>> GetAll () {
            
            try
            {
                var _cojBGPlanSum = await _context.cojBGPlanSums.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanSum.Count != 0)
                {
                    return Ok(_cojBGPlanSum);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanSum/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanSum>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanSum = await _context.cojBGPlanSums.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanSum.Count != 0)
                {
                    return Ok(_cojBGPlanSum);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanSum/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanSum>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanSum = await _context.cojBGPlanSums.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanSum.Count != 0)
                {
                    return Ok(_cojBGPlanSum);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanSum/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanSum>> GetItem (long id) {

            try
            {
                var cojBGPlanSum = await _context.cojBGPlanSums.FindAsync (id);
                
                if (cojBGPlanSum == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanSum);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanSum
        [HttpPost]
        public async Task<ActionResult<cojBGPlanSum>> CreateItem (cojBGPlanSum newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanSums.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanSums.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanSum/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanSum item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanSums.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);                
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanSums.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanSums.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanSum _itemNew = new cojBGPlanSum {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGPlanSumA = item.cojBGPlanSumA,
                    cojBGPlanSumB = item.cojBGPlanSumB,
                    cojBGPlanSumC = item.cojBGPlanSumC,
                    cojBGPlanSumAMT = item.cojBGPlanSumAMT,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanSums.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanSum/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanSums.FindAsync (id);

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