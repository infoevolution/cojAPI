using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cojApi.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Globalization;

namespace cojApi.Controllers
{
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class cojUsersController : ControllerBase
    {
        private readonly cojDBContext _context;
        private CultureInfo _culture;

        public cojUsersController(cojDBContext context)
        {
            _context = context;
            _culture = new CultureInfo("th-TH");

        }

        // GET: api/cojUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUser>>> GetUsers()
        {
            try
            {
                var _cojUser = await _context.cojUsers.Where(x => x.endDate == "31/12/9999 00:00:00").ToListAsync();
                //var password = _cojUser.Select(x => x.password = "").ToList();

                if(_cojUser.Count != 0)
                {
                    return _cojUser;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/cojUser/1
        [HttpGet("{id}")]
        public async Task<ActionResult<cojUser>> GetUser(long id)
        {
            try
            {
                
                var cojUser = await _context.cojUsers.FindAsync(id);
                if (cojUser == null)
                {                    
                    return NoContent();                    
                }

                cojUser.password = "";
                return cojUser;
                
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/cojUser/searchName
        [Route("[action]/{term}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUser>>> searchName(string term)
        {
            
            try
            {
                var _cojUser = await _context.cojUsers.Where(x => x.endDate == "31/12/9999 00:00:00" && x.firstName.ToLowerInvariant().Contains(term)).OrderBy(a => a.id).ToListAsync();

                if(_cojUser.Count != 0)
                {
                    return _cojUser;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/cojUser/GetHistory/{id}
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cojUser>>> GetHistory(long id)
        {
            try
            {
                var _cojUser = await _context.cojUsers.Where(x => x.id == id).ToListAsync();
                //_cojUser.Select(x => x.password = "").ToList();

                if(_cojUser.Count != 0)
                {
                    return _cojUser;
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/cojUser
        [HttpPost]
        public async Task<ActionResult<cojUser>> CreateCOJUser(cojUser newUser)
        {
            try
            {
                //check duplicate item id, code, name
                if(newUser.id != 0){
                    
                    return NoContent();
                }
                //

                newUser.startDate = DateTime.Now.ToString (_culture);
                newUser.endDate = "31/12/9999 00:00:00";
                
                _context.cojUsers.Add(newUser);                
                await _context.SaveChangesAsync();
                newUser.idRef = newUser.id;

                //initial new item
                // var _item = await _context.cojUsers.FindAsync (newUser.id);
                // _item.startDate = DateTime.Now.ToString (_culture);
                // _item.endDate = "31/12/9999 00:00:00";
                // _item.idRef = newUser.id;
                // _context.Entry (_item).State = EntityState.Modified;                                
                // await _context.SaveChangesAsync();
                
                return CreatedAtAction(nameof(GetUser), new { id = newUser.id }, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cojUser/2
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCOJUser(long id, cojUser user)
        {
            try
            {
                if (id != user.id)
                {
                    return NoContent();
                }

                //update endDate
                // var _item = await _context.cojUsers.FindAsync(id);
                // _item.endDate = DateTime.Now.ToString(_culture);
                // _context.Entry(_item).State = EntityState.Modified;
                // await _context.SaveChangesAsync();

                // var _items = await _context.cojUsers.Where (a => a.idRef == user.idRef && a.endDate == "31/12/9999 00:00:00").ToListAsync ();

                // foreach (var _itm in _items) {
                //     var _item = await _context.cojUsers.FindAsync (_itm.id);
                //     _item.endDate = DateTime.Now.ToString (_culture);
                //     _context.Entry (_item).State = EntityState.Modified;
                //     await _context.SaveChangesAsync ();
                // }

                cojUser _itemNew = new cojUser {

                    idRef = user.idRef,
                    userId = user.userId,
                    password = user.password,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    position = user.position,
                    cojAgencyId = user.cojAgencyId,
                    email = user.email,
                    phone = user.phone,
                    status = user.status,
                    securityKey = user.securityKey
                    // startDate = DateTime.Now.ToString(_culture),
                    // endDate = "31/12/9999 00:00:00"

                };

                _context.cojUsers.Add(_itemNew);
                await _context.SaveChangesAsync();

                return Ok(_itemNew);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/cojUser/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCOJUser(long id)
        {
            try
            {
                var cojUser = await _context.cojUsers.FindAsync(id);

                if (cojUser == null)
                {
                    return NoContent();
                }

                //update endDate
                var _item = await _context.cojUsers.FindAsync(id);
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