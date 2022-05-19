namespace aysconsultores.dotnet_azure_function.Responses;

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
