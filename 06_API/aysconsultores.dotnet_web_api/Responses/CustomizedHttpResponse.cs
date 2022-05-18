namespace aysconsultores.dotnet_web_api.Responses;

public class CustomizedHttpResponse
{
    public int Status { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public CustomizedHttpResponse()
    {
        Status = 200;
        Message = "Success";
    }
}
