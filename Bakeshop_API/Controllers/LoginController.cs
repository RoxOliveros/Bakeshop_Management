using Bakeshop_Common;
using BakeshopManagement.Business;
using Microsoft.AspNetCore.Mvc;

namespace BakeshopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("˚.🎀༘⋆ Login & Registration ˚.🎀༘⋆")]
    public class CustomerController : ControllerBase
    {
        private BakeshopProcess _process;

        public CustomerController(BakeshopProcess process)
        {
            _process = process;
        }

        // --- CUSTOMER LOGIN ---
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var isValid = _process.ValidateCustomer(login.Username, login.Password);
            if (!isValid)
                return Unauthorized("Invalid username or password");

            return Ok("Login successful");
        }

        // --- ADMIN LOGIN ---
        [HttpPost("admin")]
        public IActionResult AdminLogin([FromBody] LoginDto login)
        {
            if (login.Username == _process.adminUsername && login.Password == _process.adminPin)
                return Ok("Welcome, Admin");

            return Unauthorized("Invalid admin credentials");
        }
    


        [HttpGet("{username}")]
        public ActionResult<CustomerAccount> GetCustomer(string username)
        {
            var customer = _process.GetCustomer(username);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] CustomerAccount account)
        {
            if (_process.RegisterCustomer(account, out string error))
                return Ok();
            return BadRequest(error);
        }

        public class LoginDto
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

    }
}
