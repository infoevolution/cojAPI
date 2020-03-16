using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace cojApi.Services
{
    public class EmailService: iEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task SendEmail(string email, string subject, string message)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential 
                {
                    UserName = _config["Email:Email"],
                    Password = _config["Email:Password"]
                };
                
                client.Credentials = credential;
                client.Host = _config["Email:Host"];
                client.Port = int.Parse(_config["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(_config["Email:Email"]);
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    await client.SendMailAsync(emailMessage);
                }
            }
            await Task.CompletedTask;

            
        }

    }
}