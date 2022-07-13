namespace CoffeeShopWebApi.Decorators.ComplementDecorator;

public class Milk : ComplementDecoration
{
    public Milk(ICoffeeWrapper coffee)
        : base(coffee)
    {
    }
    public override string Description => CoffeeWrapper.Description + " with Milk";
    public override double Price => .50 + CoffeeWrapper.Price;
}