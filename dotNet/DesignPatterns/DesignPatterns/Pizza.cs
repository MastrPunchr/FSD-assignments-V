namespace DesignPatterns;

public class PizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public PizzaBuilder WithDough(string dough)
    {
        _pizza.Dough = dough;
        return this;
    }

    public PizzaBuilder WithSauce(string sauce)
    {
        _pizza.Sauce = sauce;
        return this;
    }

    public PizzaBuilder WithSize(int size)
    {
        _pizza.Size = size;
        return this;
    }

    public PizzaBuilder AddTopping(string topping)
    {
        _pizza.Toppings.Add(topping);
        return this;
    }

    public PizzaBuilder WithExtraCheese()
    {
        _pizza.ExtraCheese = true;
        return this;
    }

    public PizzaBuilder WithStuffedCrust()
    {
        _pizza.StuffedCrust = true;
        return this;
    }

    public Pizza Build()
    {
        return _pizza;
    }
}

public class Pizza
{
    public string Dough { get; set; } = "Regular";
    public string Sauce { get; set; } = "Tomato";
    public int Size { get; set; } = 12;
    public bool ExtraCheese { get; set; } = false;
    public bool StuffedCrust { get; set; } = false;
    public List<string> Toppings { get; } = new List<string>();

    public override string ToString()
    {
        string toppings = Toppings.Count == 0 ? "none" : string.Join(", ", Toppings);
        return $"{Size}\" {Dough} dough, {Sauce} sauce, toppings: {toppings}, extra cheese: {ExtraCheese}, stuffed crust: {StuffedCrust}";
    }
}