namespace CoffeeShopWebApi.Helpers;

public static class CoffeeBuilder
{
    public static void BuildCoffee(Coffee coffee, CoffeeType type)
    {
        switch (type)
        {
            case CoffeeType.Decaffeinated:
                ICoffeeWrapper decaffeinated = new Decaffeinated();
                coffee.Name += decaffeinated.Description;
                coffee.Price = decaffeinated.Price;
                break;
            case CoffeeType.Express:
                ICoffeeWrapper express = new Express();
                coffee.Name += express.Description;
                coffee.Price = express.Price;
                break;
            case CoffeeType.Smoothie:
                ICoffeeWrapper smoothie = new Smoothie();
                coffee.Name += smoothie.Description;
                coffee.Price = smoothie.Price;
                break;
        }
    }
    public static void BuildComplement(Coffee coffee, ComplementType type)
    {
        switch (type)
        {
            case ComplementType.Cream:
                ICoffeeWrapper cream = new Cream(coffee);
                coffee.Description = cream.Description;
                coffee.Price = cream.Price;
                break;
            case ComplementType.Milk:
                ICoffeeWrapper milk = new Milk(coffee);
                coffee.Description = milk.Description;
                coffee.Price = milk.Price;
                break;
            case ComplementType.Moca:
                ICoffeeWrapper moca = new Moca(coffee);
                coffee.Description = moca.Description;
                coffee.Price = moca.Price;
                break;
        }
    }
}