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
    public class cojProjectsController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojProjectsController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/v1/cojProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojProject>>> GetAllItem () {


            try
            {
                var _cojProject = await _context.cojProjects.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojProject.Count != 0)
                {
                    return Ok(_cojProject);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojProjects/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojProject>>> GetAll () {
            
            try
            {
                var _cojProject = await _context.cojProjects.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojProject.Count != 0)
                {
                    return Ok(_cojProject);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojProjects/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojProject>>> GetHistory (long id) {
            
            try
            {
                var _cojProject = await _context.cojProjects.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojProject.Count != 0)
                {
                    return Ok(_cojProject);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/v1/cojProjects/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojProject>>> searchName(string term)
        {
            
            try
            {
                var _cojProject = await _context.cojProjects.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojProject.Count != 0)
                {
                    return Ok(_cojProject);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/v1/cojProjects/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojProject>> GetItem (long id) {

            try
            {
                var cojProject = await _context.cojProjects.FindAsync (id);
                
                if (cojProject == null) {

                    return NoContent ();

                }

                    return Ok(cojProject);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/v1/cojProjects
        [HttpPost]
        public async Task<ActionResult<cojProject>> CreateItem (cojProject newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojProjects.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojProjects.FindAsync (newItem.id);
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

        // PUT: api/v1/cojProjects/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojProject item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update dateEnd
                // var _item = await _context.cojProjects.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojProjects.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojProjects.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojProject _itemNew = new cojProject {
                    idRef = item.idRef,
                    code = item.code,                    
                    name = item.name,
                    objective = item.objective,
                    projectDateStart = item.projectDateStart,
                    projectDateFinish = item.projectDateFinish,
                    scope = item.scope,
                    contactPerson = item.contactPerson,
                    contactPhone = item.contactPhone,
                    func = item.func,
                    status = item.status
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojProjects.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/v1/cojProjects/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojProjects.FindAsync (id);

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