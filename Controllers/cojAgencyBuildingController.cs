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
    public class cojAgencyBuildingController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojAgencyBuildingController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojAgencyBuilding
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuilding>>> GetAllItem () {
            try
            {
                var _cojAgencyBuilding = await _context.cojAgencyBuildings.Where (x => x.endDate == "31/12/9999 00:00:00").OrderBy (a => a.idRef).ToListAsync ();

                if(_cojAgencyBuilding.Count != 0)
                {
                    return Ok(_cojAgencyBuilding);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuilding/GetAll
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuilding>>> GetAll () {
           try
           {
               var _cojAgencyBuilding = await _context.cojAgencyBuildings.OrderBy (a => a.idRef).ToListAsync ();

               if(_cojAgencyBuilding.Count != 0)
               {
                   return Ok(_cojAgencyBuilding);
               }
               return NoContent();
           }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuilding/GetHistory
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuilding>>> GetHistory (long id) {
            
            try
            {
                var _cojAgencyBuilding = await _context.cojAgencyBuildings.Where (x => x.idRef == id).OrderByDescending (a => a.id).ToListAsync ();

                if(_cojAgencyBuilding.Count != 0)
                {
                    return Ok(_cojAgencyBuilding);
                }
                return NoContent();
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuilding/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojAgencyBuilding>>> searchName(string term)
        {
            
            try
            {
                var _cojAgencyBuilding = await _context.cojAgencyBuildings.Where(x => x.remark.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojAgencyBuilding.Count != 0)
                {
                    return _cojAgencyBuilding;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojAgencyBuilding/1
        [HttpGet ("{id}")]
        public async Task<ActionResult<cojAgencyBuilding>> GetItem (long id) {
            var cojAgencyBuilding = await _context.cojAgencyBuildings.FindAsync (id);

            try
            {
                if (cojAgencyBuilding == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuilding);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojAgencyBuilding/1
        // where ตาม cojAgency
        [HttpGet ("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<cojAgencyBuilding>>> cojAgency (long id) {

            var cojAgencyBuilding = await _context.cojAgencyBuildings.Where(x => x.cojAgencyId == id && x.endDate == "31/12/9999 00:00:00").ToListAsync();

            try
            {
                if (cojAgencyBuilding == null) {
                    return NoContent ();
                }

                return Ok(cojAgencyBuilding);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojAgencyBuilding
        [HttpPost]
        public async Task<ActionResult<cojAgencyBuilding>> CreateItem (cojAgencyBuilding newItem) {


            try
            {
                //check duplicate item id, code, name
                if(newItem.id != 0){
                    
                    return NoContent();
                }
                
                newItem.startDate = DateTime.Now.ToString (_culture);
                newItem.endDate = "31/12/9999 00:00:00";

                _context.cojAgencyBuildings.Add (newItem);
                await _context.SaveChangesAsync ();
                newItem.idRef = newItem.id;

                //initial new item
                // var _item = await _context.cojAgencyBuildings.FindAsync (newItem.id);
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

        // PUT: api/cojAgencyBuilding/2
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateItem (long id, cojAgencyBuilding item) {
            
            try
            {
                if (id != item.id) {
                    return NoContent ();
                }

                //update endDate
                // var _item = await _context.cojAgencyBuildings.FindAsync (id);
                // _item.endDate = DateTime.Now.ToString (_culture);
                // _context.Entry (_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync ();

                // var _items = await _context.cojAgencyBuildings.Where (a => a.idRef == item.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojAgencyBuildings.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                //Add new
                cojAgencyBuilding _itemNew = new cojAgencyBuilding {
                    idRef = item.idRef,
                    cojLandTypeAdocNo = item.cojLandTypeAdocNo,
                    cojLandTypeBdocNo = item.cojLandTypeBdocNo,
                    cojLandTypeCowner = item.cojLandTypeCowner,
                    cojLandTypeCdocNo = item.cojLandTypeCdocNo,
                    cojLandTypeD = item.cojLandTypeD,
                    cojLandSize = item.cojLandSize,
                    cojLandAddress = item.cojLandAddress,
                    code = item.code,
                    remark = item.remark,
                    cojAreaTotal = item.cojAreaTotal,
                    cojAreaIndorTotal = item.cojAreaTotal,
                    cojAreaIndorFloor = item.cojAreaIndorFloor,
                    cojAreaCourtroom = item.cojAreaCourtroom,
                    cojAreaCourtSize = item.cojAreaCourtSize,
                    cojAreaWorkroom = item.cojAreaWorkroom,
                    cojAreaWorkSize = item.cojAreaWorkSize,
                    cojAreaWorkWC = item.cojAreaWorkWC,
                    cojAreaServiceWC = item.cojAreaServiceWC,
                    cojAreaOutdorTotal = item.cojAreaOutdorTotal,
                    cojAreaOutdorParking = item.cojAreaOutdorParking,
                    cojAreaOutdorField = item.cojAreaOutdorField,
                    cojAreaOutdorWalkway = item.cojAreaOutdorWalkway,
                    cojAreaOutdorOther = item.cojAreaOutdorOther,
                    cojAreaGlass = item.cojAreaGlass,
                    cojHouseTotal = item.cojHouseTotal,
                    cojCondoSize = item.cojCondoSize,
                    cojCondoUnit = item.cojCondoUnit,
                    cojHousePosition = item.cojHousePosition,
                    cojHousePositionUnit = item.cojHousePositionUnit,
                    cojHouseRoom = item.cojHouseRoom,
                    cojHouseRoomArea = item.cojHouseRoomArea,
                    cojHouseFitness = item.cojHouseFitness,
                    cojHouseFitnessArea = item.cojHouseFitnessArea,
                    cojHouseCenterWC = item.cojHouseCenterWC,
                    cojHouseTank = item.cojHouseTank,
                    cojAreaIndorGlass = item.cojAreaIndorGlass,
                    buildingType = item.buildingType,
                    cojAgencyId = item.cojAgencyId
                    //name = item.name,
                    //land = item.land,
                    //space = item.space,
                    //floor = item.floor,
                    //room = item.room,
                    //throne = item.throne,
                    //workarea = item.workarea,
                    //remark = item.remark,
                    // startDate = DateTime.Now.ToString (_culture),
                    // endDate = "31/12/9999 00:00:00"
                };

                _context.cojAgencyBuildings.Add (_itemNew);
                await _context.SaveChangesAsync ();

                return Ok (_itemNew);
            }
        
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Delete : api/cojAgencyBuilding/2 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem (long id) {
            
            var _item = await _context.cojAgencyBuildings.FindAsync (id);

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