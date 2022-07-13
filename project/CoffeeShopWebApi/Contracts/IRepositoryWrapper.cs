namespace CoffeeShopWebApi.Contracts;

public interface IRepositoryWrapper
{
    Task SaveAsync();
    ICoffeeRepository Coffee { get; }
}
