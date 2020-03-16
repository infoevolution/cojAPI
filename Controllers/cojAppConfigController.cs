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
    public class cojAppConfigsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojAppConfigsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojAppConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAppConfig>>> GetAllItem () {


            try
            {
                var _cojAppConfig = await _context.cojAppConfigs.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojAppConfig.Count != 0)
                {
                    return Ok(_cojAppConfig);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojAppConfig/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAppConfig>>> GetAll () {
            
            try
            {
                var _cojAppConfig = await _context.cojAppConfigs.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojAppConfig.Count != 0)
                {
                    return Ok(_cojAppConfig);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAppConfigs/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAppConfig>>> GetHistory (long id) {
            
            try
            {
                var _cojAppConfig = await _context.cojAppConfigs.Where (x => x.idRef == id && x.endDate == "31/12/9999 00:00:00").OrderByDescending (a => a.id).ToListAsync ();

                if(_cojAppConfig.Count != 0)
                {
                    return Ok(_cojAppConfig);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAppConfigs/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojAppConfig>> GetItem (long id) {

            try
            {
                var cojAppConfig = await _context.cojAppConfigs.FindAsync (id);
                
                if (cojAppConfig == null) {

                    return NoContent ();

                }

                    return Ok(cojAppConfig);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        // POST: api/cojAppConfig
        [HttpPost]
        public async Task<ActionResult<cojAppConfig>> CreateItem (cojAppConfig newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //

                _context.cojAppConfigs.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                return CreatedAtAction (nameof (GetItem), new { id = newItem.id }, newItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojAppConfig/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojAppConfig item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //Add new
                cojAppConfig _itemNew = new cojAppConfig {
                    idRef = item.idRef,
                    configCode = item.configCode,
                    configName = item.configName,
                    configValue = item.configValue,
                    remark = item.remark,
                    configType = item.configType,
                    configRight = item.configRight,
                    startDate = item.startDate,
                    endDate = item.endDate,
                    status = item.status,
                    userCreate = item.userCreate,
                    userUpdate = item.userUpdate,
                    userAudit = item.userAudit,
                    userAuditDate = item.userAuditDate,
                    userApprove = item.userApprove,
                    userApproveDate = item.userApproveDate
                };

                _context.cojAppConfigs.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojAppConfig/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojAppConfigs.FindAsync (id);

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