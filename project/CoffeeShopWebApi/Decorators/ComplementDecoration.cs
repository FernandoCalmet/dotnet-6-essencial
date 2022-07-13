namespace CoffeeShopWebApi.Decorators;

public class ComplementDecoration : CoffeeDecoration
{
    public ComplementDecoration(ICoffeeWrapper coffee)
        : base(coffee)
    {
    }
    public override string Description => CoffeeWrapper.Description;
    public override double Price => CoffeeWrapper.Price;
}