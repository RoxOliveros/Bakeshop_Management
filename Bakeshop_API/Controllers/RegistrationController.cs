using Email;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
      

        private readonly Email.EmailService _emailService;


        public AccountController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-welcome")]
        public IActionResult SendWelcomeEmail(string name, string email)
        {
            _emailService.SendEmail(name, email);
            return Ok("Email sent successfully!");
        }
    }
}
