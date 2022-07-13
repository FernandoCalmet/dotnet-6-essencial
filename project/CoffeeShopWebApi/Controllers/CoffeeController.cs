using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoffeeController : ControllerBase
{
    private readonly ICoffeeService _service;
    private readonly ILogger<CoffeeController> _logger;
    private readonly HttpApiResponse _response;
    public CoffeeController(ICoffeeService service, ILogger<CoffeeController> logger)
    {
        _service = service;
        _logger = logger;
        _response = new HttpApiResponse();
    }
    [HttpPost]
    public ActionResult<Coffee> CreateCoffee([FromQuery] CreateCoffeeQuery query)
    {
        try
        {
            var data = _service.HandleQueryAsync(query);
            _response.Status = 200;
            _response.Data = data.Result;
            _response.Message = "Coffee created successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "Error occured while creating coffee";
            _response.Data = null;
            return BadRequest(_response);
        }
    }
    [HttpPut]
    public ActionResult<Coffee> UpdateCoffee([FromBody] UpdateCoffeeCommand command)
    {
        try
        {
            var data = _service.HandleCommandAsync(command);
            if (data == null)
            {
                _response.Status = 404;
                _response.Message = "Coffee not found";
                _response.Data = null;
                return NotFound(_response);
            }
            _response.Status = 200;
            _response.Data = data.Result;
            _response.Message = "Coffee updated successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "Error occured while updating coffee";
            _response.Data = null;
            return BadRequest(_response);
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<Coffee> DeleteCoffee(string id)
    {
        try
        {

            var query = new DeleteCoffeeQuery(Guid.Parse(id));
            var data = _service.HandleQueryAsync(query);
            if (data == null)
            {
                _response.Status = 404;
                _response.Message = "Coffee not found";
                _response.Data = null;
                return NotFound(_response);
            }
            _response.Status = 200;
            _response.Data = data.Result;
            _response.Message = "Coffee deleted successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "Error occured while deleting coffee";
            _response.Data = null;
            return BadRequest(_response);
        }
    }
    [HttpGet]
    public ActionResult<Coffee> GetAllCoffees([FromQuery] string value)
    {
        try
        {
            var query = new GetCoffeeQuery(value);
            var data = _service.HandleQueryAsync(query);
            if (data == null)
            {
                _response.Status = 404;
                _response.Message = "Coffee not found";
                _response.Data = null;
                return NotFound(_response);
            }
            _response.Status = 200;
            _response.Data = data.Result;
            _response.Message = "Coffees fetched successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "Error occured while fetching coffees";
            _response.Data = null;
            return BadRequest(_response);
        }
    }
    [HttpGet("{value}")]
    public ActionResult<Coffee> GetCoffee(string value)
    {
        try
        {
            var query = new GetCoffeeQuery(value);
            var data = _service.HandleQueryAsync(query);
            if (data == null)
            {
                _response.Status = 404;
                _response.Message = "Coffee not found";
                _response.Data = null;
                return NotFound(_response);
            }
            _response.Status = 200;
            _response.Data = data.Result;
            _response.Message = "Coffee found successfully";
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            _response.Status = 400;
            _response.Message = "Error occured while finding coffee";
            _response.Data = null;
            return BadRequest(_response);
        }
    }
}
