namespace CoffeeShopWebApi.Decorators.ComplementDecorator;

public class Moca : ComplementDecoration
{
    public Moca(ICoffeeWrapper coffee)
        : base(coffee)
    {
    }
    public override string Description => CoffeeWrapper.Description + " with Moca";
    public override double Price => .35 + CoffeeWrapper.Price;
}