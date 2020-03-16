using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using cojApi.Models;
using cojApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cojApi.Controllers {
    [Route ("api/v1/[controller]")]
    [ApiController]

    public class cojMailController : ControllerBase {
        private readonly iEmailService _emailService;

        public cojMailController (iEmailService emailService) {
            _emailService = emailService;
        }

        [Route ("[action]")]
        [HttpPost]
        public async Task<IActionResult> sendEmail ([FromBody] cojMail email) {

            try {
                await _emailService.SendEmail (email.email, email.subject, email.message);
                return Ok ();
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }

        }

    }
}