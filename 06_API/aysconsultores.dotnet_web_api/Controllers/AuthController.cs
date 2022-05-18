using aysconsultores.dotnet_web_api.Contracts;
using aysconsultores.dotnet_web_api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aysconsultores.dotnet_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("auth/login")]
    public async Task<IActionResult> Login([FromBody] string username, string password)
    {
        var token = await _userService.AuthenticateAsync(username, password);

        if (token != null)
        {
            return Ok(new AuthenticatedResponse { Token = token });
        }

        return Unauthorized();
    }
}
