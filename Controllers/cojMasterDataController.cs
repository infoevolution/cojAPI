using System.Xml.Linq;
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
    public class cojMasterDataController : ControllerBase
    {    
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        // private cojDataCategory _dataCategory;
        // private cojMasterData _dataMasterData;

        public cojMasterDataController(cojDBContext context)
        {
            _context = context;
            _culture = new CultureInfo("th-TH");

        }

        // GET: api/cojMasterData/category/{idCategory}
        [Route("category/{idDataCategory}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojMasterData>>> getCategory(long idDataCategory)
        {            
            try
            {
                var _cojMasterData = await _context.cojMasterDatas.Where(x => x.endDate == "31/12/9999 00:00:00" && x.idDataCategory == idDataCategory).OrderBy(a => a.idRef).ToListAsync();
                
                if(_cojMasterData.Count != 0)
                {
                    return _cojMasterData;
                }
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojMasterData/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojMasterData>>> GetAllMasterData()
        {
            try
            {
                var _cojMasterData = await _context.cojMasterDatas.Where(x => x.endDate == "31/12/9999 00:00:00").OrderBy(a => a.idRef).ToListAsync();

                if(_cojMasterData.Count != 0)
                {
                    return _cojMasterData;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojMasterData//{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<cojMasterData>>> GetItem(long id)
        {
            var _cojMasterData = await _context.cojMasterDatas.FindAsync (id);

            try
            {
                if (_cojMasterData == null) {
                    return NoContent();
                }

                return Ok(_cojMasterData);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojMasterData/GetHistory/{id}
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojMasterData>>> GetHistory(long id)
        {
            try
            {
                var _cojMasterData = await _context.cojMasterDatas.Where(x => x.id == id).ToListAsync();

                if(_cojMasterData.Count != 0)
                {
                    return _cojMasterData;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojMasterData/category/GetAll/{idCategory}
        [Route("category/[action]/{idDataCategory}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojMasterData>>> GetAll(long idDataCategory)
        {
            try
            {
                var _cojMasterData = await _context.cojMasterDatas.Where(x => x.idDataCategory == idDataCategory).OrderBy(a => a.idRef).ToListAsync();

                if(_cojMasterData.Count != 0)
                {
                    return _cojMasterData;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojMasterData/category/drstchName/{idDataCategory}/{term}
        [Route("category/[action]/{idDataCategory}/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojMasterData>>> searchName(long idDataCategory, string term)
        {
            try
            {
                var _cojMasterData = await _context.cojMasterDatas.Where(x => x.idDataCategory == idDataCategory && x.name.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();
                
                if(_cojMasterData.Count != 0)
                {
                    return _cojMasterData;
                }
                return  NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST: api/v1/cojMasterData
        [HttpPost]
        public async Task<ActionResult<cojMasterData>> CreateItem(cojMasterData newItem)
        {

            try
            {
                if (newItem.id != 0)
                {
                    return NoContent();
                }

                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.createDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";    

                _context.cojMasterDatas.Add(newItem);
                await _context.SaveChangesAsync();
                newItem.idRef = newItem.id;

                //initial new item
                var _item = await _context.cojMasterDatas.FindAsync(newItem.id);

                //ตรวจสอบรหัส ถ้าไม่ระบุให้กำหนดค่าจาก id
                if(newItem.code == null || newItem.code.Length == 0){
                    _item.code = newItem.id.ToString();
                } else {
                    _item.code = newItem.code;
                }


                // _item.code = newItem.id.ToString();
                // _item.startDate = DateTime.Now.ToString(_culture);
                // _item.createDate = DateTime.Now.ToString(_culture);                
                // _item.endDate = "31/12/9999 00:00:00";
                // _item.idRef = newItem.id;
                // _item.idDataCategory = newItem.idDataCategory;
                // _context.Entry(_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetItem), new { id = newItem.id }, newItem);             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/v1/cojMasterData/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id, cojMasterData item)
        {
            try
            {
                if (id != item.id)
                {
                    return NoContent();
                }

                //update endDate
                // var _item = await _context.cojMasterDatas.FindAsync(id);
                // _item.endDate = DateTime.Now.ToString(_culture);
                // _context.Entry(_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync();

                // var _items = await _context.cojMasterDatas.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojMasterDatas.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojMasterData _itemNew = new cojMasterData { 
                    idRef= item.idRef, 
                    code= item.code,
                    name= item.name,
                    idDataCategory= item.idDataCategory,
                    idParent= item.idParent,
                    updateDate= DateTime.Now.ToString(_culture),
                    // createDate = DateTime.Now.ToString(_culture),
                    // startDate = DateTime.Now.ToString(_culture),
                    // endDate = "31/12/9999 00:00:00",
                    status = item.status,
                    userUpdate = item.userUpdate,
                    userAudit = item.userAudit,
                    userAuditDate = item.userAuditDate,
                    userApprove = item.userApprove,
                    userApproveDate = item.userApproveDate,
                    remark = item.remark,
                    formData = item.formData,
                    docData = item.docData
                    };

                _context.cojMasterDatas.Add(_itemNew);
                await _context.SaveChangesAsync();

                return Ok(_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //DELETE: api/v1/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            try
            {
                var cojMasterData = await _context.cojMasterDatas.FindAsync(id);

            if (cojMasterData == null)
            {
                return NoContent();
            }

            //update endDate
            var _item = await _context.cojMasterDatas.FindAsync(id);
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