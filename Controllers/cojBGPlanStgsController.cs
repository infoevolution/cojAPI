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
    public class cojBGPlanStgsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanStgsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanStg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanStg>>> GetAllItem () {


            try
            {
                var _cojBGPlanStg = await _context.cojBGPlanStgs.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanStg.Count != 0)
                {
                    return Ok(_cojBGPlanStg);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanStg/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanStg>>> GetAll () {
            
            try
            {
                var _cojBGPlanStg = await _context.cojBGPlanStgs.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanStg.Count != 0)
                {
                    return Ok(_cojBGPlanStg);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanStg/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanStg>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanStg = await _context.cojBGPlanStgs.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanStg.Count != 0)
                {
                    return Ok(_cojBGPlanStg);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanStg/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanStg>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanStg = await _context.cojBGPlanStgs.Where(x => x.nameEN.ToLowerInvariant().Contains(term) || x.nameTH.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanStg.Count != 0)
                {
                    return Ok(_cojBGPlanStg);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanStg/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanStg>> GetItem (long id) {

            try
            {
                var cojBGPlanStg = await _context.cojBGPlanStgs.FindAsync (id);
                
                if (cojBGPlanStg == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanStg);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanStg
        [HttpPost]
        public async Task<ActionResult<cojBGPlanStg>> CreateItem (cojBGPlanStg newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanStgs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanStgs.FindAsync (newItem.id);
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

    //    // PUT: api/cojBGPlanStg/2
    //     [HttpPut ("{id}")]
    //     public async Task<IActionResult> UpdateItem (long id, cojBGPlanStg item) {
            
    //         try
    //         {
    //             if (id != item.id) {
    //             return NoContent ();
    //             }

    //             //update endDate
    //             var _item = await _context.cojBGPlanStgs.FindAsync (id);
    //             _item.endDate = DateTime.Now.ToString (_culture); 

    //             _context.Entry (_item).State = EntityState.Modified;
    //             await _context.SaveChangesAsync ();

    //             //Add new
    //             cojBGPlanStg _itemNew = new cojBGPlanStg {
    //                 idRef = item.idRef,
    //                 code = item.code,
    //                 nameEN = item.nameEN,
    //                 nameTH = item.nameTH,
    //                 cojBGPlanId = item.cojBGPlanId,
    //                 cojStgId = item.cojStgId,
    //                 cojStgPlanId = item.cojStgPlanId,
    //                 cojBGPlanSumA = item.cojBGPlanSumA,
    //                 cojBGPlanSumB = item.cojBGPlanSumB,
    //                 cojBGPlanSumC = item.cojBGPlanSumC,
    //                 cojBGPlanSumAMT = item.cojBGPlanSumAMT,
    //                 cojBGPlanSumWork = item.cojBGPlanSumWork,
    //                 cojBGPlanSumProject = item.cojBGPlanSumProject,
    //                 remark = item.remark,
    //                 startDate = DateTime.Now.ToString (_culture),
    //                 endDate = "31/12/9999 00:00:00"
    //             };

    //             _context.cojBGPlanStgs.Add (_itemNew);
    //             await _context.SaveChangesAsync ();

    //             return Ok (_itemNew);
    //         }
    //         catch (Exception ex)
    //         {
    //             return BadRequest(ex.Message);
    //         }

    //     }
        // PUT: api/cojBGPlanStg/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanStg item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanStgs.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture); 
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                //  var _items = await _context.cojBGPlanStgs.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanStgs.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanStg _itemNew = new cojBGPlanStg {
                    idRef = item.idRef,
                    code = item.code,
                    nameEN = item.nameEN,
                    nameTH = item.nameTH,
                    cojBGPlanId = item.cojBGPlanId,
                    cojStgId = item.cojStgId,
                    cojStgPlanId = item.cojStgPlanId,
                    cojBGPlanSumA = item.cojBGPlanSumA,
                    cojBGPlanSumB = item.cojBGPlanSumB,
                    cojBGPlanSumC = item.cojBGPlanSumC,
                    cojBGPlanSumAMT = item.cojBGPlanSumAMT,
                    cojBGPlanSumWork = item.cojBGPlanSumWork,
                    cojBGPlanSumProject = item.cojBGPlanSumProject,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojBGPlanStgs.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanStg/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanStgs.FindAsync (id);

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