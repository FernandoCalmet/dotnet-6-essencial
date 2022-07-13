namespace CoffeeShopWebApi.Decorators.CoffeeDecorator;

public class Smoothie : ICoffeeWrapper
{
    private readonly string _description;
    public Smoothie() => _description = "Smoothie";
    public string Description => _description;
    public double Price => 2.5;
}