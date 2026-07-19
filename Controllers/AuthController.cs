using Microsoft.AspNetCore.Mvc;
using RosterManagementSystem.DTOs.Auth;
using RosterManagementSystem.Services.Interfaces;

namespace RosterManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);

            if (result == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(result);
        }
    }
}