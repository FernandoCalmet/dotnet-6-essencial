using aysconsultores.dotnet_web_api.Contracts;
using aysconsultores.dotnet_web_api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aysconsultores.dotnet_web_api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        var userCreated = await _userService.AddAsync(user);
        return Ok(userCreated);
    }

    [HttpPut]
    public async Task<IActionResult> EditUser([FromBody] User user)
    {
        var userUpdated = await _userService.EditAsync(user);
        return Ok(userUpdated);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUser([FromBody] User user)
    {
        var result = await _userService.RemoveAsync(user);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleAsync(string value)
    {
        var user = await _userService.GetSingleAsync(value);

        if (user == null)
            return NotFound();

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();

        if (users == null)
            return NotFound();

        return Ok(users);
    }

    [HttpGet("/check/{id}")]
    public async Task<IActionResult> CheckIfExistsAsync(int id)
    {
        return Ok(await _userService.CheckIfExistsAsync(id));
    }
}
