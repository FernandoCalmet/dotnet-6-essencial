namespace CoffeeShopWebApi.Contracts;

public interface ICoffeeService
{
    Task<Coffee> HandleCommandAsync(UpdateCoffeeCommand command);
    Task<Coffee> HandleQueryAsync(CreateCoffeeQuery query);    
    Task<bool> HandleQueryAsync(DeleteCoffeeQuery query);
    Task<IEnumerable<Coffee>> HandleQueryAsync(GetAllCoffeesQuery query);
    Task<Coffee> HandleQueryAsync(GetCoffeeQuery query);
}