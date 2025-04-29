using Xunit;
using System.Linq;

public class CoffeeBuilderTests
{
    [Fact]
    public void Build_Espresso_ShouldContainOneBlackCoffee()
    {
        var builder = new CoffeeBuilder();
        var coffee = builder.AddBlackCoffee().Build();

        Assert.Single(coffee.Ingredients);
        Assert.Equal("Black coffee", coffee.Ingredients[0]);
    }

    [Fact]
    public void Build_Cappuccino_ShouldContainBlackCoffeeAndMilk()
    {
        var builder = new CoffeeBuilder();
        var coffee = builder.AddBlackCoffee().AddMilk().Build();

        Assert.Equal(2, coffee.Ingredients.Count);
        Assert.Contains("Black coffee", coffee.Ingredients);
        Assert.Contains("Regular milk", coffee.Ingredients);
    }

    [Fact]
    public void Build_FlatWhite_WithOatMilkAndSugar_ShouldContainCorrectIngredients()
    {
        var builder = new CoffeeBuilder();
        var coffee = builder
            .AddBlackCoffee()
            .AddBlackCoffee()
            .AddMilk("Oat milk")
            .AddSugar()
            .Build();

        Assert.Equal(4, coffee.Ingredients.Count);
        Assert.Equal(2, coffee.Ingredients.Count(i => i == "Black coffee"));
        Assert.Contains("Oat milk", coffee.Ingredients);
        Assert.Contains("Sugar", coffee.Ingredients);
    }

    [Fact]
    public void Build_ShouldResetBuilderAfterBuild()
    {
        var builder = new CoffeeBuilder();

        var firstCoffee = builder.AddBlackCoffee().Build();
        var secondCoffee = builder.Build(); // Should be empty

        Assert.Single(firstCoffee.Ingredients);
        Assert.Empty(secondCoffee.Ingredients);
    }
}
