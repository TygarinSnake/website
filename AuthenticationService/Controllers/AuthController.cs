using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Entitys;
using AuthenticationService.Models;
using Microsoft.Extensions.Configuration;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User userModel)
        {
            var response = new AuthenticateResponse(userModel, "Token");
            //if (response == null)
            //{
            //    return BadRequest(new { message = "Didn't register!" });
            //}

            return Ok(response);
        }

        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization(User userModel)
        {
            var response = new AuthenticateResponse(userModel, "Token");

            //if (response == null)
            //{
            //    return BadRequest(new { message = "Didn't register!" });
            //}

            return Ok(response);
        }
    }
}
