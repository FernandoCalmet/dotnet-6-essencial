namespace CoffeeShopWebApi.Decorators.CoffeeDecorator;

public class Decaffeinated : ICoffeeWrapper
{
    private readonly string _description;
    public Decaffeinated() => _description = "Decaffeinated";
    public string Description => _description;
    public double Price => 2.2;
}