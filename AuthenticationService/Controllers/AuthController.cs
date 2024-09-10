using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Entitys;
using AuthenticationService.Models;
using Microsoft.Extensions.Configuration;
using AuthenticationService.Attributes;
using Microsoft.AspNetCore.Mvc.Filters;
using AuthenticationService.Helpers;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User userModel)
        {
            string token = _configuration.GenerateJwtToken(userModel);
            var response = new AuthenticateResponse(userModel, token);
            if (response == null)
            {
                return BadRequest(new { message = "Didn't register!" });
            }

            return Ok(response);
        }

        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization(User userModel)
        {
            var response = new AuthenticateResponse(userModel, "Token");

            if (response == null)
            {
                return BadRequest(new { message = "Didn't register!" });
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            //var users = _userService.GetAll();
            return Ok(new User());
        }
    }
}
