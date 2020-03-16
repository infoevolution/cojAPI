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
    public class cojBGPlanWorkplansController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanWorkplansController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanWorkplan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplan>>> GetAllItem () {


            try
            {
                var _cojBGPlanWorkplans = await _context.cojBGPlanWorkplans.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanWorkplans.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplans);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanWorkplan/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplan>>> GetAll () {
            
            try
            {
                var _cojBGPlanWorkplans = await _context.cojBGPlanWorkplans.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanWorkplans.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplans);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplan/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplan>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanWorkplans = await _context.cojBGPlanWorkplans.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanWorkplans.Count != 0)
                {
                    return Ok(_cojBGPlanWorkplans);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // GET: api/cojBGPlanWorkplan/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkplan>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanWorkplans = await _context.cojBGPlanWorkplans.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojBGPlanWorkplans.Count != 0) {
                   return Ok(_cojBGPlanWorkplans);
                }

               return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanWorkplan/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanWorkplan>> GetItem (long id) {

            try
            {
                var _cojBGPlanWorkplans = await _context.cojBGPlanWorkplans.FindAsync (id);
                
                if (_cojBGPlanWorkplans == null) {

                    return NoContent ();

                }

                    return Ok(_cojBGPlanWorkplans);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanWorkplan
        [HttpPost]
        public async Task<ActionResult<cojBGPlanWorkplan>> CreateItem (cojBGPlanWorkplan newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanWorkplans.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanWorkplans.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanWorkplan/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanWorkplan item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojBGPlanWorkplans.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanWorkplans.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanWorkplans.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojBGPlanWorkplan _itemNew = new cojBGPlanWorkplan {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    cojBGPlanId = item.cojBGPlanId,
                    cojStgPlanId = item.cojStgPlanId,
                    cojStgId = item.cojStgId,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    cojBGPlanSumA = item.cojBGPlanSumA,
                    cojBGPlanSumB = item.cojBGPlanSumB,
                    cojBGPlanSumC = item.cojBGPlanSumC,
                    cojBGPlanSumAMT = item.cojBGPlanSumAMT,
                    cojBGPlanTotalAMT = item.cojBGPlanTotalAMT,
                    cojBGPlanTotalAMTShow = item.cojBGPlanTotalAMTShow,
                    cojAgencys = item.cojAgencys,
                    cojAgencysFulltext = item.cojAgencysFulltext,
                    remark = item.remark,
                    procumentAgency = item.procumentAgency,
                    disbursementAgency = item.disbursementAgency,
                    responsibilityAgency = item.responsibilityAgency
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanWorkplans.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanWorkplan/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanWorkplans.FindAsync (id);

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