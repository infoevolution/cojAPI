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
    public class cojBGPlanManageRequestsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojBGPlanManageRequestsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojBGPlanManageRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanManageRequest>>> GetAllItem () {


            try
            {
                var _cojBGPlanManageRequest = await _context.cojBGPlanManageRequests.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojBGPlanManageRequest.Count != 0)
                {
                    return Ok(_cojBGPlanManageRequest);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojBGPlanManageRequests/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanManageRequest>>> GetAll () {
            
            try
            {
                var _cojBGPlanManageRequest = await _context.cojBGPlanManageRequests.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojBGPlanManageRequest.Count != 0)
                {
                    return Ok(_cojBGPlanManageRequest);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanManageRequests/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanManageRequest>>> GetHistory (long id) {
            
            try
            {
                var _cojBGPlanManageRequest = await _context.cojBGPlanManageRequests.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojBGPlanManageRequest.Count != 0)
                {
                    return Ok(_cojBGPlanManageRequest);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojBGPlanManageRequests/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojBGPlanManageRequest>>> searchName(string term)
        {
            
            try
            {
                var _cojBGPlanManageRequest = await _context.cojBGPlanManageRequests.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojBGPlanManageRequest.Count != 0)
                {
                    return Ok(_cojBGPlanManageRequest);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojBGPlanManageRequests/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojBGPlanManageRequest>> GetItem (long id) {

            try
            {
                var cojBGPlanManageRequest = await _context.cojBGPlanManageRequests.FindAsync (id);
                
                if (cojBGPlanManageRequest == null) {

                    return NoContent ();

                }

                    return Ok(cojBGPlanManageRequest);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojBGPlanManageRequests
        [HttpPost]
        public async Task<ActionResult<cojBGPlanManageRequest>> CreateItem (cojBGPlanManageRequest newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojBGPlanManageRequests.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojBGPlanManageRequests.FindAsync (newItem.id);
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

        // PUT: api/cojBGPlanManageRequests/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojBGPlanManageRequest item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojBGPlanManageRequests.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture); 
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojBGPlanManageRequests.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojBGPlanManageRequests.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojBGPlanManageRequest _itemNew = new cojBGPlanManageRequest {
                    idRef = item.idRef,
                    code = item.code,
                    name = item.name,
                    userCreate = item.userCreate,
                    userUpdate = item.userUpdate,
                    userAudit = item.userAudit,
                    userAuditDate = item.userAuditDate,
                    userApprove = item.userApprove,
                    userApproveDate = item.userApproveDate,
                    formData = item.formData,
                    docData = item.docData,
                    cojAgencyId = item.cojAgencyId,
                    cojPeriod = item.cojPeriod,
                    cojBGPlanManageRequestStatus = item.cojBGPlanManageRequestStatus,
                    cojBGPlanManageType = item.cojBGPlanManageType,
                    cojWorkplanTypeId = item.cojWorkplanTypeId,
                    cojBGWorkplanId = item.cojBGWorkplanId,
                    remark = item.remark
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojBGPlanManageRequests/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojBGPlanManageRequests.FindAsync (id);

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