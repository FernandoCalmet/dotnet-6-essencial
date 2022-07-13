using aysconsultores.dotnet_azure_function.Contracts;
using aysconsultores.dotnet_azure_function.Models;
using aysconsultores.dotnet_azure_function.Responses;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace aysconsultores.dotnet_azure_function.Functions;

public class AuthFunctions
{
    private readonly IUserService _userService;
    private readonly ILogger _logger;
    //private readonly CustomizedHttpResponse _response;
    private const string Route = "auth";

    public AuthFunctions(ILoggerFactory loggerFactory, IUserService userService/*, CustomizedHttpResponse response*/)
    {
        _logger = loggerFactory.CreateLogger<AuthFunctions>();
        _userService = userService;
        //_response = response;
    }

    [Function("Login")]
    public async Task<HttpResponseData> Login(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = Route)] HttpRequestData req)
    {
        try
        {
            var body = await req.ReadFromJsonAsync<LoginModel>();
            var token = await _userService.AuthenticateAsync(body.UserName, body.Password);

            if (token != null)
            {
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                var data = new AuthenticatedResponse { Token = token };
                //_response.Status = 200;
                //_response.Message = "Login Successful";
                //_response.Data = data;
                await response.WriteAsJsonAsync(data);
                return response;
            }

            return req.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            //_response.Status = 400;
            //_response.Message = "Login Failed";
            //_response.Data = null;
            return req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
