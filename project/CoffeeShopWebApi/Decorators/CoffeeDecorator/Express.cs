namespace CoffeeShopWebApi.Decorators.CoffeeDecorator;

public class Express : ICoffeeWrapper
{
    private readonly string _description;
    public Express() => _description = "Express";
    public string Description => _description;
    public double Price => 1.2;
}