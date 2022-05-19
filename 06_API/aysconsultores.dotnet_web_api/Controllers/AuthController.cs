using aysconsultores.dotnet_web_api.Contracts;
using aysconsultores.dotnet_web_api.Models;
using aysconsultores.dotnet_web_api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aysconsultores.dotnet_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;
    private readonly CustomizedHttpResponse _response;

    public AuthController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
        _response = new CustomizedHttpResponse();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel user)
    {
        try
        {
            var token = await _userService.AuthenticateAsync(user.UserName, user.Password);

            if (token != null)
            {
                var data = new AuthenticatedResponse { Token = token };
                _response.Status = 200;
                _response.Message = "Login Successful";
                _response.Data = data;
                return Ok(_response);
            }

            return Unauthorized();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "Login Failed";
            _response.Data = null;
            return BadRequest(_response);
        }
    }
}
