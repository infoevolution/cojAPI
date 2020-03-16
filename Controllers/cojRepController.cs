using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using cojApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cojApi.Controllers {
    //[Authorize]
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class cojRepController : ControllerBase {
        private readonly cojDBContext _context;
        private CultureInfo _culture;
        public cojRepController (cojDBContext context) {
            _context = context;
            _culture = new CultureInfo ("th-TH");

        }

        [Route ("[action]")]
        [HttpPost]
        public IActionResult getReport (spParam data) {
            try {

                var url = $"{data.data}".Replace ("\n", "");

                CredentialCache cc = new CredentialCache();

                cc.Add(
                    new Uri("http://10.100.77.51/ReportServer"),
                    "NTLM",
                    new NetworkCredential("administrator", "Bpr!101007751")
                );

                WebRequest request = WebRequest.Create (url);

                request.Credentials = cc;

                HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
                Stream stream = response.GetResponseStream ();

                return File (stream, "application/pdf");

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [Route ("[action]")]
        [HttpPost]
        public IActionResult getPDF (spParam data) {
            try {

                var url = $"{data.data}".Replace ("\n", "");

                CredentialCache cc = new CredentialCache();

                cc.Add(
                    new Uri(url),
                    "NTLM",
                    new NetworkCredential(@"administrator", "Bpr!101007751", "bprDbm01")
                );

                WebRequest request = WebRequest.Create (url);

                request.Credentials = cc;

                HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
                Stream stream = response.GetResponseStream ();

                return File (stream, "application/pdf");

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

    }
    
}