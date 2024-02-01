using ExtremeClassified.WebApi.Dtos.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("TestCode")]
        public IActionResult TestCode()
        {
            return Ok("Application is running");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            return Ok(new { Message = "Working... one 2 5 ==>" + dto.Password });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {

            return Ok(new { Message = "Registration successful for email: " + dto.Email });
        }
    }
}
