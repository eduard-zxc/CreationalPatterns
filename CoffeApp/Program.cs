
public class Coffee
{
    private readonly List<string> _ingredients = new();

    public void Add(string ingredient) => _ingredients.Add(ingredient);

    public void Display()
    {
        Console.WriteLine("Coffee contains:");
        foreach (var ingredient in _ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }
    }
}

public interface ICoffeeBuilder
{
    void Reset();
    ICoffeeBuilder AddBlackCoffee();
    ICoffeeBuilder AddMilk(string type = "Regular milk");
    ICoffeeBuilder AddSugar();
    Coffee Build();
}

public class CoffeeBuilder : ICoffeeBuilder
{
    private Coffee _coffee = new();

    public void Reset() => _coffee = new Coffee();

    public ICoffeeBuilder AddBlackCoffee()
    {
        _coffee.Add("Black coffee");
        return this;
    }

    public ICoffeeBuilder AddMilk(string type = "Regular milk")
    {
        _coffee.Add(type);
        return this;
    }

    public ICoffeeBuilder AddSugar()
    {
        _coffee.Add("Sugar");
        return this;
    }

    public Coffee Build()
    {
        var result = _coffee;
        Reset();
        return result;
    }
}

class Program
{
    static void Main()
    {
        var builder = new CoffeeBuilder();

        var espressoCustom = builder
            .AddBlackCoffee()
            .AddMilk("Soy milk")
            .AddSugar()
            .Build();
        espressoCustom.Display();

        Console.WriteLine();

        var cappuccinoCustom = builder
            .AddBlackCoffee()
            .AddMilk("Regular milk")
            .AddSugar()
            .AddSugar()
            .Build();
        cappuccinoCustom.Display();

        Console.WriteLine();

        var flatWhiteCustom = builder
            .AddBlackCoffee()
            .AddBlackCoffee()
            .AddMilk("Oat milk")
            .AddSugar()
            .Build();
        flatWhiteCustom.Display();
    }
}
