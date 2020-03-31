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
using Newtonsoft.Json.Linq;

namespace cojApi.Controllers {
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class cojVWController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojVWController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        // GET: api/cojVW/vwCojRegionReserveFYWorkActivityBudgetTypes
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojRegionReserveFYWorkActivityBudgetType>>> vwCojRegionReserveFYWorkActivityBudgetTypes () {

            try {
                var _ret = await _context.vwCojRegionReserveFYWorkActivityBudgetTypes.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }


        // GET: api/cojVW/vwCojRegionReserveFYWorkActivitys
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojRegionReserveFYWorkActivity>>> vwCojRegionReserveFYWorkActivitys () {

            try {
                var _ret = await _context.vwCojRegionReserveFYWorkActivitys.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojVW/vwCojRegionReserveFYWorks
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojRegionReserveFYWork>>> vwCojRegionReserveFYWorks () {

            try {
                var _ret = await _context.vwCojRegionReserveFYWorks.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojVW/vwCojRegionReserveFYAgencys
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojRegionReserveFYAgency>>> vwCojRegionReserveFYAgencys () {

            try {
                var _ret = await _context.vwCojRegionReserveFYAgencys.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

    }
}