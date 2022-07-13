namespace CoffeeShopWebApi.Services;

public class CoffeeService : ICoffeeService
{
    private readonly IRepositoryWrapper _repository;
    public CoffeeService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }
    public async Task<Coffee> HandleCommandAsync(UpdateCoffeeCommand command)
    {
        var coffee = await _repository.Coffee.GetCoffee(command.Id.ToString());
        CoffeeBuilder.BuildCoffee(coffee, command.CoffeeType);
        CoffeeBuilder.BuildComplement(coffee, command.ComplementType);
        _repository.Coffee.UpdateCoffee(coffee);
        await _repository.SaveAsync();
        return coffee;
    }
    public async Task<Coffee> HandleQueryAsync(CreateCoffeeQuery query)
    {
        var coffee = new Coffee
        {
            Id = Guid.NewGuid(),
            Name = "Coffee ",
            OrderDate = DateTime.UtcNow
        };
        CoffeeBuilder.BuildCoffee(coffee, query.CoffeeType);
        CoffeeBuilder.BuildComplement(coffee, query.ComplementType);
        _repository.Coffee.CreateCoffee(coffee);
        await _repository.SaveAsync();
        return coffee;
    }
    public async Task<bool> HandleQueryAsync(DeleteCoffeeQuery query)
    {
        var coffee = await _repository.Coffee.GetCoffee(query.Id.ToString());
        _repository.Coffee.DeleteCoffee(coffee);
        await _repository.SaveAsync();
        return true;
    }
    public async Task<IEnumerable<Coffee>> HandleQueryAsync(GetAllCoffeesQuery query) =>
        await _repository.Coffee.GetAllCoffees();
    public async Task<Coffee> HandleQueryAsync(GetCoffeeQuery query) =>
        await _repository.Coffee.GetCoffee(query.Value);
}