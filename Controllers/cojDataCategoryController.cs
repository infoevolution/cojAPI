using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cojApi.Models;
using System.Globalization;

namespace cojApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class cojDataCategoryController : ControllerBase
    {    
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojDataCategoryController(cojDBContext context)
        {
            _context = context;
            _culture = new CultureInfo("th-TH");

        }

        // GET: api/cojDataCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojDataCategory>>> GetAllItem()
        {
            
            try
            {
                var _cojDataCategory = await _context.cojDataCategorys.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy(a => a.idRef).ToListAsync();
                
                if(_cojDataCategory.Count != 0)
                {
                    return _cojDataCategory;
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojDataCategory/GetAll
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojDataCategory>>> GetAll()
        {
            try
            {
                var _cojDataCategory = await _context.cojDataCategorys.OrderBy(a => a.idRef).ToListAsync();

                if(_cojDataCategory.Count != 0)
                {
                    return _cojDataCategory;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojDataCategory/GetHistory
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojDataCategory>>> GetHistory(long id)
        {
            try
            {
                var _cojDataCategory = await _context.cojDataCategorys.Where(x => x.idRef == id).OrderByDescending(a => a.id).ToListAsync();
                
                if(_cojDataCategory.Count != 0)
                {
                    return _cojDataCategory;
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojDataCategory/1
        [HttpGet("{id}")]
        public async Task<ActionResult<cojDataCategory>> GetItem(long id)
        {
            try
            {
                var cojDataCategory = await _context.cojDataCategorys.FindAsync(id);

                if (cojDataCategory == null)
                {
                    return NoContent();
                }

                return cojDataCategory;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/cojDataCategory/searchName/{term}
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojDataCategory>>> searchName(string term)
        {
            
            try
            {
                var _cojDataCategory = await _context.cojDataCategorys.Where(x => x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojDataCategory.Count != 0)
                {
                    return _cojDataCategory;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST: api/cojDataCategory
        [HttpPost]
        public async Task<ActionResult<cojDataCategory>> CreateItem(cojDataCategory newItem)
        {

            try
            {
                if (newItem.id != 0)
                {
                    return NoContent();
                }
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";
                
                _context.cojDataCategorys.Add(newItem);
                await _context.SaveChangesAsync();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojDataCategorys.FindAsync(newItem.id);
                // _item.createDate = DateTime.Now.ToString(_culture);
                // _item.startDate = DateTime.Now.ToString(_culture);
                // _item.endDate = "31/12/9999 00:00:00";
                // _item.idRef = newItem.id;
                // _item.status = newItem.status;
                // _context.Entry(_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetItem), new { id = newItem.id }, newItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/cojDataCategory/2
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id, cojDataCategory item)
        {
            try
            {
                if (id != item.id)
                {
                    return NoContent();
                }

                //update endDate
                // var _item = await _context.cojDataCategorys.FindAsync(id);
                // _item.endDate = DateTime.Now.ToString(_culture);
                // _item.updateDate = DateTime.Now.ToString (_culture);
                // // _item.status = 0;
                // _context.Entry(_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync();

                // var _items = await _context.cojDataCategorys.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojDataCategorys.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //      _item.updateDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }


                //Add new
                cojDataCategory _itemNew = new cojDataCategory { 
                    idRef=item.idRef, 
                    itemSort = item.itemSort,
                    code=item.code,
                    name=item.name, 
                    description=item.description,
                    status = item.status
                    // createDate = DateTime.Now.ToString(_culture),
                    // startDate = DateTime.Now.ToString(_culture),
                    // endDate = "31/12/9999 00:00:00"
                    };

                _context.cojDataCategorys.Add(_itemNew);
                await _context.SaveChangesAsync();

                return Ok(_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //DELETE: api/cojDataCategory/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            try
            {
                var cojDataCategory = await _context.cojDataCategorys.FindAsync(id);

                if (cojDataCategory == null)
                {
                    return NoContent();
                }

                //update endDate
                var _item = await _context.cojDataCategorys.FindAsync(id);
                _item.endDate = DateTime.Now.ToString(_culture);
                _context.Entry(_item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return  Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}