namespace CoffeeShopWebApi.Contracts;

public interface ICoffeeWrapper
{
    string Description { get; }
    double Price { get; }
}