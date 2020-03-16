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
    public class cojSPController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojSPController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        //ftbl 

        // POST: api/cojSP/fblCojBGPlanQuarter
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojBGPlanQuarter>>> fblCojBGPlanQuarter (paramCojBGPlanQuarter p) {

            try {
                
                var _ret = await _context.fblCojBGPlanQuarter.FromSql ($"select * from fbl_cojBGPlanQuarter({p.fy}, {p.cojBGWorkplanId}, {p.cojWorkActivityId}, {p.cojBudgetTypeId})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYAgencyAccountRI
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYAgencyAccountRI>>> fblCojFYAgencyAccountRI (paramCojStg p) {

            try {
                var _ret = await _context.fblCojFYAgencyAccountRI.FromSql ($"select * from fbl_cojAgencyAccountRI({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYCojStg
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYCojStg>>> fblCojFYCojStgs (paramCojStg p) {

            try {
                var _ret = await _context.fblCojFYCojStg.FromSql ($"select * from fbl_cojFYCojStg({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYCojStgWorkplanTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYCojStgWorkplanType>>> fblCojFYCojStgWorkplanTypes (paramCojStg p) {

            try {
                var _ret = await _context.fblCojFYCojStgWorkplanType.FromSql ($"select * from fbl_cojFYCojStgWorkplanType({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYCojStgWorkplans
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYCojStgWorkplan>>> fblCojFYCojStgWorkplans (paramCojStg p) {

            try {
                var _ret = await _context.fblCojFYCojStgWorkplan.FromSql ($"select * from fbl_cojFYCojStgWorkplan({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYCojStgWorkplanActivitys
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYCojStgWorkplanActivity>>> fblCojFYCojStgWorkplanActivitys (paramCojStg p) {

            try {
                var _ret = await _context.fblCojFYCojStgWorkplanActivity.FromSql ($"select * from fbl_cojFYCojStgWorkplanActivity({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYCojStgWorkplanActivityBGTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYCojStgWorkplanActivityBGType>>> fblCojFYCojStgWorkplanActivityBGTypes (paramCojStg p) {

            try {
                var _ret = await _context.fblCojFYCojStgWorkplanActivityBGType.FromSql ($"select * from fbl_cojFYCojStgWorkplanActivityBGType({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYCojStgWorkplanActivityBGTypeFunds
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYCojStgWorkplanActivityBGTypeFund>>> fblCojFYCojStgWorkplanActivityBGTypeFunds (paramCojStg p) {

            try {
                var _ret = await _context.fblCojFYCojStgWorkplanActivityBGTypeFund.FromSql ($"select * from fbl_cojFYCojStgWorkplanActivityBGTypeFund({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        //*****************************************************
        // POST: api/cojSP/fblCojFYWorkplanTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYWorkplanType>>> fblCojFYWorkplanTypes (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.fblCojFYWorkplanType.FromSql ($"select * from fbl_cojFYWorkplanType({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYWorkplans
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYWorkplan>>> fblCojFYWorkplans (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.fblCojFYWorkplan.FromSql ($"select * from fbl_cojFYWorkplan({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYWorkplanActivitys
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYWorkplanActivity>>> fblCojFYWorkplanActivitys (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.fblCojFYWorkplanActivity.FromSql ($"select * from fbl_cojFYWorkplanActivity({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYWorkplanActivityBGTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYWorkplanActivityBGType>>> fblCojFYWorkplanActivityBGTypes (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.fblCojFYWorkplanActivityBGType.FromSql ($"select * from fbl_cojFYWorkplanActivityBGType({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/fblCojFYWorkplanActivityBGTypeFunds
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<fblCojFYWorkplanActivityBGTypeFund>>> fblCojFYWorkplanActivityBGTypeFunds (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.fblCojFYWorkplanActivityBGTypeFund.FromSql ($"select * from fbl_cojFYWorkplanActivityBGTypeFund({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGPlanWorks
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGPlanWork>>> cojBGPlanWorks (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.ftblCojBGPlanWork.FromSql ($"select * from fbl_cojBGPlanWork({p.fy})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGPlanWorkActivitys
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkActivity>>> cojBGPlanWorkActivitys (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.ftblCojBGPlanWorkActivity.FromSql ($"select * from fbl_cojBGPlanWorkActivity({p.fy}, {p.cojBGWorkplan})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGPlanWorkActivityBGTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkActivityBGType>>> cojBGPlanWorkActivityBGTypes (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.ftblCojBGPlanWorkActivityBGType.FromSql ($"select * from fbl_cojBGPlanWorkActivityBGType({p.fy}, {p.cojBGWorkplan}, {p.cojBudgetType})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGPlanWorkActivityBGTypeFunds
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkActivityBGTypeFund>>> cojBGPlanWorkActivityBGTypeFunds (paramCojBGPlanWork p) {

            try {
                var _ret = await _context.ftblCojBGPlanWorkActivityBGTypeFund.FromSql ($"select * from fbl_cojBGPlanWorkActivityBGTypeFund({p.fy}, {p.cojBGWorkplan}, {p.cojBudgetType})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }


        // POST: api/cojSP/cojBGPlanWorkActivityFunds
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<cojBGPlanWorkActivityFund>>> cojBGPlanWorkActivityFunds (paramCojBGPlanWorkFund p) {

            try {
                var _ret = await _context.ftblCojBGPlanWorkActivityFund.FromSql ($"select * from fbl_cojBGPlanWorkActivityFund({p.fy}, {p.cojBGWorkplan}, {p.cojFund})").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGPlanTransferAllotPost
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spRet>>> cojBGPlanTransferAllotPost (spParam data) {

            try {
                var _ret = await _context.sp_cojBGPlanTransferAllotPost.FromSql ($"sp_cojBGPlanTransferAllotPost {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        //** add 28-01-63 -> start

        // POST: api/cojSP/cojBGTransferRequestAgencyProposeSumCOJs
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyProposeSumCOJ>>> cojBGTransferRequestAgencyProposeSumCOJs (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferRequestAgencyProposeSumCOJ.FromSql ($"sp_cojBGTransferRequestAgencyProposeSumCOJ {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestAgencyProposeSumAgencyType
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyProposeSumAgencyType>>> cojBGTransferRequestAgencyProposeSumAgencyTypes (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferRequestAgencyProposeSumAgencyType.FromSql ($"sp_cojBGTransferRequestAgencyProposeSumAgencyType {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestAgencyProposeSumAgencyAccount
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyProposeSumAgencyAccount>>> cojBGTransferRequestAgencyProposeSumAgencyAccounts (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferRequestAgencyProposeSumAgencyAccount.FromSql ($"sp_cojBGTransferRequestAgencyProposeSumAgencyAccount {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        //** add 28-01-63 --> end

        //** add 09-02-63 --> start
        // POST: api/cojSP/cojBGTransferApproveGetDocuments
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferApproveGetDocument>>> cojBGTransferApproveGetDocuments (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferApproveGetDocument.FromSql ($"sp_cojBGTransferApproveGetDocument {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }
        //** add 09-02-63 --> end



        //** add 27-01-63
        // POST: api/cojSP/cojTransferRequestAgencys
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<vwCojBGTransferRequestAgency>>> cojTransferRequestAgencys (spCojFYTransferRequest data) {

            try {
                var _ret = await _context.vwCojBGTransferRequestAgencys.Where(a => a.transferFy==data.transferFy).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojTransferRequestAgencyItems
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<vwCojBGTransferRequestAgencyItem>>> cojTransferRequestAgencyItems (spCojFYTransferRequest data) {

            try {
                var _ret = await _context.vwCojBGTransferRequestAgencyItems.Where(a => a.transferFy==data.transferFy).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojTransferRequestAgencyProposes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyPropose>>> cojTransferRequestAgencyProposes (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferRequestAgencyPropose.FromSql ($"sp_cojBGTransferRequestAgencyPropose {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }
        // end 27-01-63 ----------------

        // GET: api/cojSP/cojAgencyAccountBooks
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAgencyAccountBook>>> cojAgencyAccountBooks () {

            try {
                var _ret = await _context.vwCojAgencyAccountBooks.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferFYs
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferFY>>> cojAllotRequestTransferFYs () {

            try {
                var _ret = await _context.vwCojAllotRequestTransferFYs.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlans
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlan>>> cojAllotRequestTransferBGPlans () {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlans.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlans/id
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlan>>> cojAllotRequestTransferBGPlans (long id) {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlans.Where(a => a.cojBGPlanId==id).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkplanTypes
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkplanType>>> cojAllotRequestTransferBGPlanWorkplanTypes () {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkplanTypes.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkplanTypes
        [Route ("[action]/{bgPlanId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkplanType>>> cojAllotRequestTransferBGPlanWorkplanTypes (long bgPlanId) {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkplanTypes.Where(a => a.cojBGPlanId==bgPlanId).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkplans
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkplan>>> cojAllotRequestTransferBGPlanWorkplans () {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkplans.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkplans
        [Route ("[action]/{bgPlanId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkplan>>> cojAllotRequestTransferBGPlanWorkplans (long bgPlanId) {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkplans.Where(a => a.cojBGPlanId==bgPlanId).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkActivityBudgetTypes
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkActivityBudgetType>>> cojAllotRequestTransferBGPlanWorkActivityBudgetTypes () {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkActivityBudgetTypes.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }
        
        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkActivityBudgetTypes
        [Route ("[action]/{bgPlanId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkActivityBudgetType>>> cojAllotRequestTransferBGPlanWorkActivityBudgetTypes (long bgPlanId) {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkActivityBudgetTypes.Where(a => a.cojBGPlanId==bgPlanId).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkActivitys 
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkActivity>>> cojAllotRequestTransferBGPlanWorkActivitys () {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkActivitys.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }


        // GET: api/cojSP/cojAllotRequestTransferBGPlanWorkActivitys 
        [Route ("[action]/{bgPlanId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojAllotRequestTransferBGPlanWorkActivity>>> cojAllotRequestTransferBGPlanWorkActivitys (long bgPlanId) {

            try {
                var _ret = await _context.vwCojAllotRequestTransferBGPlanWorkActivitys.Where(a => a.cojBGPlanId==bgPlanId).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllots
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllot>>> cojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllots () {

            try {
                var _ret = await _context.vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllots.ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllots
        [Route ("[action]/{bgPlanId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllot>>> cojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllots (long bgPlanId) {

            try {
                var _ret = await _context.vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllots.Where(a => a.cojBGPlanId==bgPlanId).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFY
        [Route ("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<spCojFY>>> cojFYs () {

            try {
                var _ret = await _context.spCojFYs.FromSql ($"sp_cojFY").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojFYTransferAllotQuaterAllotType
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spRet>>> cojFYTransferAllotQuaterAllotType (paramCojFYTransferAllotQuater data) {

            try {
                var _ret = await _context.spRet.FromSql ($"sp_cojFYTransferAllotQuaterAllotType {data.fy}, {data.quater}, {data.allotType}").ToListAsync ();


                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }


        // POST: api/cojSP/cojFYWorkplanType
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYWorkplanType>>> cojFYWorkplanTypes (spCojFYWorkplanType data) {

            try {
                var _ret = await _context.spCojFYWorkplanTypes.FromSql ($"sp_cojFYWorkplanType {data.fy}").ToListAsync ();

                if (data.cojWorkplanTypeId > 0) {
                    _ret = _ret.Where (a => a.cojWorkplanTypeId == data.cojWorkplanTypeId).ToList ();
                }

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojFYWorkplan
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYWorkplan>>> cojFYWorkplans (spCojFYWorkplan data) {

            try {
                var _ret = await _context.spCojFYWorkplans.FromSql ($"sp_cojFYWorkplan {data.fy}").ToListAsync ();

                if (data.cojWorkplanTypeId > 0) {
                    _ret = _ret.Where (a => a.cojWorkplanTypeId == data.cojWorkplanTypeId).ToList ();
                }

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojFYWorkplanFund
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYWorkplanFund>>> cojFYWorkplanFunds (spCojFYWorkplanFund data) {

            try {
                var _ret = await _context.spCojFYWorkplanFunds.FromSql ($"sp_cojFYWorkplanFund {data.fy}").ToListAsync ();

                if (_ret.Count != 0) {

                    if (data.cojWorkplanTypeId > 0) {
                        _ret = _ret.Where (a => a.cojWorkplanTypeId == data.cojWorkplanTypeId).ToList ();
                    }

                    return _ret;

                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFYWorkplanActivity
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYWorkplanActivity>>> cojFYWorkplanActivitys (spCojFYWorkplanActivity data) {

            try {
                var _ret = await _context.spCojFYWorkplanActivitys.FromSql ($"sp_cojFYWorkplanActivity {data.fy}").ToListAsync ();

                if (_ret.Count != 0) {

                    if (data.cojWorkplanTypeId > 0) {
                        _ret = _ret.Where (a => a.cojWorkplanTypeId == data.cojWorkplanTypeId).ToList ();
                    }

                    if (data.cojBGWorkplanId > 0) {
                        _ret = _ret.Where (a => a.cojBGWorkplanId == data.cojBGWorkplanId).ToList ();
                    }

                    return _ret;

                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFYWorkplanActivityFund
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYWorkplanActivityFund>>> cojFYWorkplanActivityFunds (spCojFYWorkplanActivityFund data) {

            try {
                var _ret = await _context.spCojFYWorkplanActivityFunds.FromSql ($"sp_cojFYWorkplanActivityFund {data.fy}").ToListAsync ();

                if (_ret.Count != 0) {

                    if (data.cojWorkplanTypeId > 0) {
                        _ret = _ret.Where (a => a.cojWorkplanTypeId == data.cojWorkplanTypeId).ToList ();
                    }

                    if (data.cojBGWorkplanId > 0) {
                        _ret = _ret.Where (a => a.cojBGWorkplanId == data.cojBGWorkplanId).ToList ();
                    }

                    return _ret;

                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        //** add : 26-01-2563
        // GET: api/cojSP/cojFYWorkplanActivityBGTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYWorkplanActivityBGType>>> cojFYWorkplanActivityBGTypes (spCojFYWorkplanActivityBGType data) {

            try {
                var _ret = await _context.spCojFYWorkplanActivityBGTypes.FromSql ($"sp_cojFYWorkplanActivityBGType {data.fy}").ToListAsync ();

                if (_ret.Count != 0) {

                    if (data.cojWorkplanTypeId > 0) {
                        _ret = _ret.Where (a => a.cojWorkplanTypeId == data.cojWorkplanTypeId).ToList ();
                    }

                    if (data.cojBGWorkplanId > 0) {
                        _ret = _ret.Where (a => a.cojBGWorkplanId == data.cojBGWorkplanId).ToList ();
                    }

                    return _ret;

                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }
        // GET: api/cojSP/cojFYTransferAllotWorks
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYTransferAllotWork>>> cojFYTransferAllotWorks (spCojFYTransferAllotWork data) {

            try {
                var _ret = await _context.spCojFYTransferAllotWorks.FromSql ($"sp_cojFYTransferAllotWork {data.fy}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFYTransferAllotWorkAgencyTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYTransferAllotWorkAgencyType>>> cojFYTransferAllotWorkAgencyTypes (spCojFYTransferAllotWorkAgencyType data) {

            try {
                var _ret = await _context.spCojFYTransferAllotWorkAgencyTypes.FromSql ($"sp_cojFYTransferAllotWorkAgencyType {data.fy}, {data.quater}, {data.allotType}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFYTransferAllotWorkAgencys
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYTransferAllotWorkAgency>>> cojFYTransferAllotWorkAgencys (spCojFYTransferAllotWorkAgency data) {

            try {
                var _ret = await _context.spCojFYTransferAllotWorkAgencys.FromSql ($"sp_cojFYTransferAllotWorkAgency {data.fy}, {data.quater}, {data.allotType}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFYTransferAllotWorkAgencyDetails
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYTransferAllotWorkAgencyDetail>>> cojFYTransferAllotWorkAgencyDetails (spCojFYTransferAllotWorkAgencyDetail data) {

            try {
                var _ret = await _context.spCojFYTransferAllotWorkAgencyDetails.FromSql ($"sp_cojFYTransferAllotWorkAgencyDetail {data.fy}, {data.quater}, {data.allotType}, {data.cojAgencyId}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGPlanAllotPost
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spRet>>> cojBGPlanAllotPost (spParam data) {

            try {
                var _ret = await _context.sp_cojBGPlanAllotPost.FromSql ($"sp_cojBGPlanAllotPost {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestAgencys
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgency>>> cojBGTransferRequestAgencys (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencys.FromSql ($"sp_cojBGTransferRequestGetAgency {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }
        
        // POST: api/cojSP/cojBGTransferRequestAgencyTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyType>>> cojBGTransferRequestAgencyTypes (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencyTypes.FromSql ($"sp_cojBGTransferRequestGetAgencyType {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestAgencyDetails
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyDetail>>> cojBGTransferRequestAgencyDetails (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencyDetails.FromSql ($"sp_cojBGTransferRequestGetAgencyDetail {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestAgencyDetailItems
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyDetailItem>>> cojBGTransferRequestAgencyDetailItems (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencyDetailItems.FromSql ($"sp_cojBGTransferRequestGetAgencyDetailItem {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestPost
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spRet>>> cojBGTransferRequestPost (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferRequestPost.FromSql ($"sp_cojBGTransferRequestPost {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestProposePost
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spRet>>> cojBGTransferRequestProposePost (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferRequestProposePost.FromSql ($"sp_cojBGTransferRequestProposePost {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferRequestApprovePost
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spRet>>> cojBGTransferRequestApprovePost (spParam data) {

            try {
                var _ret = await _context.sp_cojBGTransferRequestApprovePost.FromSql ($"sp_cojBGTransferRequestApprovePost {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFYTransferRequests
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYTransferRequest>>> cojFYTransferRequests (spCojFYTransferRequest data) {

            try {
                var _ret = await _context.spCojFYTransferRequests.FromSql ($"sp_cojFYTransferRequest {data.transferFy}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojFYTransferApproves
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojFYTransferApprove>>> cojFYTransferApproves (spCojFYTransferApprove data) {

            try {
                var _ret = await _context.spCojFYTransferApproves.FromSql ($"sp_cojFYTransferApprove {data.bgApproveFy}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojBGTransferRequest
        [Route ("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojBGTransferRequest>>> cojBGTransferRequests (long id) {

            try {
                var _ret = await _context.vwCojBGTransferRequests.Where (x => x.idRef == id).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // GET: api/cojSP/cojBGTransferApprove
        [Route ("[action]/{fy}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwCojBGTransferApprove>>> cojBGTransferApproves (long fy) {

            try {
                var _ret = await _context.vwCojBGTransferApproves.Where (x => x.bgApproveFy == fy).ToListAsync ();

                if (_ret.Count != 0) {
                    return Ok (_ret);
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // เสนอโอน
        // POST: api/cojSP/cojBGTransferAgencys
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgency>>> cojBGTransferAgencys (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencys.FromSql ($"sp_cojBGTransferGetAgency {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferAgencyTypes
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyType>>> cojBGTransferAgencyTypes (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencyTypes.FromSql ($"sp_cojBGTransferGetAgencyType {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferAgencyDetails
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyDetail>>> cojBGTransferAgencyDetails (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencyDetails.FromSql ($"sp_cojBGTransferGetAgencyDetail {data.data}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBGTransferAgencyDetailItems
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spCojBGTransferRequestAgencyDetailItem>>> cojBGTransferAgencyDetailItems (spParam data) {

            try {
                var _ret = await _context.spCojBGTransferRequestAgencyDetailItems.FromSql ($"sp_cojBGTransferGetAgencyDetailItem {data.data}").ToListAsync ();
                
                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        // POST: api/cojSP/cojBISWorkCarryOver
        [Route ("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<spRet>>> cojBISWorkCarryOver(spParam data) {

            try {

                //dynamic _dt = JsonConvert.DeserializeObject(data.data);
                dynamic _dt = JObject.Parse(data.data);
                int _fy = Convert.ToInt32(_dt.fy);

                var _ret = await _context.sp_cojBISWorkCarryOver.FromSql ($"sp_cojBISWorkCarryOver {_fy}").ToListAsync ();

                if (_ret.Count != 0) {
                    return _ret;
                }
                return NoContent ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

    }
}