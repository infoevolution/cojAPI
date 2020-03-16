using System.Threading.Tasks;

namespace cojApi.Services
{
    public interface iEmailService
    {
      Task SendEmail(string email, string subject,  string message);  
    } 
}