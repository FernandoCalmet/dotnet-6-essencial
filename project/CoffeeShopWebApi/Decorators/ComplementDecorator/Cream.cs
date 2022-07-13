namespace CoffeeShopWebApi.Decorators.ComplementDecorator;

public class Cream : ComplementDecoration
{
    public Cream(ICoffeeWrapper coffee)
        : base(coffee)
    {
    }
    public override string Description => CoffeeWrapper.Description + " with Cream";
    public override double Price => .10 + CoffeeWrapper.Price;
}