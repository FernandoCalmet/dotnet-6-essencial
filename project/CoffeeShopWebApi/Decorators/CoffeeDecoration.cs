namespace CoffeeShopWebApi.Decorators;

public abstract class CoffeeDecoration : ICoffeeWrapper
{
    protected ICoffeeWrapper CoffeeWrapper { get; set; }
    public CoffeeDecoration(ICoffeeWrapper coffee)
    {
        CoffeeWrapper = coffee;
    }
    public virtual string Description => CoffeeWrapper.Description;
    public virtual double Price => CoffeeWrapper.Price;
}