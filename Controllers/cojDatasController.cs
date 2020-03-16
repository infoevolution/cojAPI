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
    public class cojDatasController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojDatasController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojData>>> GetAllItem () {


            try
            {
                var _cojData = await _context.cojDatas.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojData.Count != 0)
                {
                    return Ok(_cojData);
                }
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GET: api/cojData/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojData>>> GetAll () {
            
            try
            {
                var _cojData = await _context.cojDatas.OrderBy (a => a.idRef).ToListAsync ();

                if(_cojData.Count != 0)
                {
                    return Ok(_cojData);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojData/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojData>>> GetHistory (long id) {
            
            try
            {
                var _cojData = await _context.cojDatas.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojData.Count != 0)
                {
                    return Ok(_cojData);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojData/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojData>>> searchName(string term)
        {
            
            try
            {
                var _cojData = await _context.cojDatas.Where(x => x.value.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojData.Count != 0)
                {
                    return Ok(_cojData);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojData/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojData>> GetItem (long id) {

            try
            {
                var cojData = await _context.cojDatas.FindAsync (id);
                
                if (cojData == null) {

                    return NoContent ();

                }

                    return Ok(cojData);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            
        }

        // POST: api/cojData
        [HttpPost]
        public async Task<ActionResult<cojData>> CreateItem (cojData newItem) {
            
            
            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                //
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojDatas.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojDatas.FindAsync (newItem.id);
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

        [Route("[action]")]  // POST: api/cojData/UploadItem
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojData>>> UploadItem (cojData[] newItems) {
            
            try
            {
                foreach (var _itm in newItems) {

                    cojData newItem = new cojData {
                    idRef = 0,
                    key = _itm.key,
                    label =_itm.label,
                    order = _itm.order,
                    value = _itm.value,
                    required = _itm.required,
                    controlType = _itm.controlType,
                    show = _itm.show,
                    disabled = _itm.disabled,
                    type = _itm.type,
                    options = _itm.options,
                    remark = _itm.remark,
                    dataCategory = _itm.dataCategory,
                    startDate = "",
                    endDate = ""
                    };
                    
                    _context.cojDatas.Add (newItem);
                    await _context.SaveChangesAsync ();
                    newItem.idRef = newItem.id;

                    //initial new item
                    // var _item = await _context.cojDatas.FindAsync (newItem.id);
                    // _item.startDate = DateTime.Now.ToString (_culture);                
                    // _item.endDate = "31/12/9999 00:00:00";
                    // _item.idRef = newItem.id;
                    // _context.Entry (_item).State = EntityState.Modified;
                    // await _context.SaveChangesAsync ();
                }

                var _cojData = await _context.cojDatas.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();
                
                if(_cojData.Count != 0)
                {
                    return Ok(_cojData);
                }

                return NoContent();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // PUT: api/cojData/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojData item) {
            
            try
            {
                if (id != item.id) {
                return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojDatas.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture); 
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojDatas.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojDatas.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojData _itemNew = new cojData {
                    idRef = item.idRef,
                    key = item.key,
                    label = item.label,
                    order = item.order,
                    value = item.value,
                    required = item.required,
                    controlType = item.controlType,
                    show = item.show,
                    disabled = item.disabled,
                    type = item.type,
                    options = item.options,
                    remark = item.remark,
                    dataCategory = item.dataCategory
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojDatas.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete : api/cojData/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojDatas.FindAsync (id);

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