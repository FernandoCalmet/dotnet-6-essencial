namespace CoffeeShopWebApi.Helpers;

public class HttpApiResponse
{
    public int Status { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public HttpApiResponse()
    {
        Status = 200;
        Message = "Success";
    }
}