using aysconsultores.dotnet_web_api.Contracts;
using aysconsultores.dotnet_web_api.Entities;
using aysconsultores.dotnet_web_api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aysconsultores.dotnet_web_api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;
    private readonly CustomizedHttpResponse _response;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
        _response = new CustomizedHttpResponse();
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        try
        {
            var data = await _userService.AddAsync(user);
            _response.Status = 200;
            _response.Data = data;
            _response.Message = "User created successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "User created failed";
            _response.Data = null;
            return BadRequest(_response);
        }
    }

    [HttpPut]
    public async Task<IActionResult> EditUser([FromBody] User user)
    {
        try
        {
            var data = await _userService.EditAsync(user);
            _response.Status = 200;
            _response.Data = data;
            _response.Message = "User updated successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "User updated failed";
            _response.Data = null;
            return BadRequest(_response);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUser(int id)
    {
        try
        {
            var data = await _userService.RemoveAsync(id);
            _response.Status = 200;
            _response.Data = data;
            _response.Message = "User removed successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "User removed failed";
            _response.Data = null;
            return BadRequest(_response);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleAsync(string value)
    {
        try
        {
            var data = await _userService.GetSingleAsync(value);

            if (data == null)
            {
                _response.Status = 404;
                _response.Message = "User not found";
                _response.Data = null;
                return NotFound(_response);
            }

            _response.Status = 200;
            _response.Data = data;
            _response.Message = "User retrieved successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "User retrieved failed";
            _response.Data = null;
            return BadRequest(_response);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var data = await _userService.GetAllAsync();

            if (data == null)
            {
                _response.Status = 404;
                _response.Message = "Users not found";
                _response.Data = null;
                return NotFound(_response);
            }

            _response.Status = 200;
            _response.Data = data;
            _response.Message = "Users retrieved successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "Users retrieved failed";
            _response.Data = null;
            return BadRequest(_response);
        }
    }

    [HttpGet("/check/{id}")]
    public async Task<IActionResult> CheckIfExistsAsync(int id)
    {
        try
        {
            var data = await _userService.CheckIfExistsAsync(id);

            if (!data)
            {
                _response.Status = 404;
                _response.Message = "User not found";
                _response.Data = null;
                return NotFound(_response);
            }

            _response.Status = 200;
            _response.Data = data;
            _response.Message = "User retrieved successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "User retrieved failed";
            _response.Data = null;
            return BadRequest(_response);
        }
    }
}
