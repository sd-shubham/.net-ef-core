using CoreAPIAndEfCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoreAPIAndEfCore.Dtos;

namespace CoreAPIAndEfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto user) => Ok(await _authService.Register(user));
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto user) => Ok(await _authService.Login(user));
    }
}