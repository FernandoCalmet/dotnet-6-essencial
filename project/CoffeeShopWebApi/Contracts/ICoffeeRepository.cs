namespace CoffeeShopWebApi.Contracts;

public interface ICoffeeRepository : IRepositoryBase<Coffee>
{
    void CreateCoffee(Coffee coffee);
    void UpdateCoffee(Coffee coffee);
    void DeleteCoffee(Coffee coffee);
    Task<IEnumerable<Coffee>> GetAllCoffees();
    Task<Coffee> GetCoffee(string value);
}