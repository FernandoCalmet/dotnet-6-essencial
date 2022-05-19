using aysconsultores.dotnet_azure_function.Contracts;
using aysconsultores.dotnet_azure_function.Entities;
using aysconsultores.dotnet_azure_function.Responses;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace aysconsultores.dotnet_azure_function.Functions
{
    public class UserFunctions
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        private readonly CustomizedHttpResponse _response;
        private const string Route = "user";

        public UserFunctions(ILoggerFactory loggerFactory, IUserService userService, CustomizedHttpResponse response)
        {
            _logger = loggerFactory.CreateLogger<UserFunctions>();
            _userService = userService;
            _response = response;
        }

        [Function("AddUser")]
        public async Task<HttpResponseData> Add(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = Route)] HttpRequestData req)
        {
            try
            {
                var body = await req.ReadFromJsonAsync<User>();
                var data = await _userService.AddAsync(body);
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                _response.Status = 200;
                _response.Data = data;
                _response.Message = "User created successfully";
                await response.WriteAsJsonAsync(_response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.Status = 400;
                _response.Message = "User created failed";
                _response.Data = null;
                return req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
        }

        [Function("EditUser")]
        public async Task<HttpResponseData> Edit(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = Route)] HttpRequestData req)
        {
            try
            {
                var body = await req.ReadFromJsonAsync<User>();
                var data = await _userService.EditAsync(body);
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                _response.Status = 200;
                _response.Data = data;
                _response.Message = "User updated successfully";
                await response.WriteAsJsonAsync(_response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.Status = 400;
                _response.Message = "User updated failed";
                _response.Data = null;
                return req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
        }

        [Function("RemoveUser")]
        public async Task<HttpResponseData> Remove(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = Route + "/{id}")] HttpRequestData req,
            int id)
        {
            try
            {
                var data = await _userService.RemoveAsync(id);
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                _response.Status = 200;
                _response.Data = data;
                _response.Message = "User updated successfully";
                await response.WriteAsJsonAsync(_response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.Status = 400;
                _response.Message = "User updated failed";
                _response.Data = null;
                return req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
        }

        [Function("GetSingleUser")]
        public async Task<HttpResponseData> GetSingle(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = Route + "/{value}")] HttpRequestData req,
            string value)
        {
            try
            {
                var data = await _userService.GetSingleAsync(value);

                if (data == null)
                {
                    var badresponse = req.CreateResponse(System.Net.HttpStatusCode.NotFound);
                    _response.Status = 404;
                    _response.Message = "User not found";
                    _response.Data = null;
                    await badresponse.WriteAsJsonAsync(_response);
                    return badresponse;
                }

                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                _response.Status = 200;
                _response.Data = data;
                _response.Message = "User retrieved successfully";
                await response.WriteAsJsonAsync(_response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.Status = 400;
                _response.Message = "User retrieved failed";
                _response.Data = null;
                return req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
        }

        [Function("GetAllUsers")]
        public async Task<HttpResponseData> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = Route)] HttpRequestData req)
        {
            try
            {
                var data = await _userService.GetAllAsync();

                if (data == null)
                {
                    var badresponse = req.CreateResponse(System.Net.HttpStatusCode.NotFound);
                    _response.Status = 404;
                    _response.Message = "User not found";
                    _response.Data = null;
                    await badresponse.WriteAsJsonAsync(_response);
                    return badresponse;
                }

                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                _response.Status = 200;
                _response.Data = data;
                _response.Message = "User retrieved successfully";
                await response.WriteAsJsonAsync(_response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.Status = 400;
                _response.Message = "User retrieved failed";
                _response.Data = null;
                return req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
        }

        [Function("CheckIfExistsUser")]
        public async Task<HttpResponseData> CheckIfExists(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = Route + "/check/{id}")] HttpRequestData req,
            int id)
        {
            try
            {
                var data = await _userService.CheckIfExistsAsync(id);

                if (!data)
                {
                    var badresponse = req.CreateResponse(System.Net.HttpStatusCode.NotFound);
                    _response.Status = 404;
                    _response.Message = "User not found";
                    _response.Data = null;
                    await badresponse.WriteAsJsonAsync(_response);
                    return badresponse;
                }

                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                _response.Status = 200;
                _response.Data = data;
                _response.Message = "User retrieved successfully";
                await response.WriteAsJsonAsync(_response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.Status = 400;
                _response.Message = "User retrieved failed";
                _response.Data = null;
                return req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
