namespace CoffeeShopWebApi.Commands;

public record UpdateCoffeeCommand(Guid Id, CoffeeType CoffeeType, ComplementType ComplementType);