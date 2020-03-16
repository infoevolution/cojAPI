using System.Net.Http;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace cojApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route ("[action]")]
        [HttpGet] 
        public  ActionResult pdfReport() {
            NetworkCredential nwc = new NetworkCredential("cojbpr", "cojbpr!2019");
            WebClient client = new WebClient();
            client.Credentials = nwc;
            string reportURL = "http://172.22.120.242/reportserver?/WRP_coj%2FWRP_RptCOJStgPlan&rs:Command=Render&rs:Format=PDF";

            return File(client.DownloadData(reportURL), "application/pdf");
        }
        
        // GET api/values
       
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
 
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
