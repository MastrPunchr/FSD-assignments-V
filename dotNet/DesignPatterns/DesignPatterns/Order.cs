namespace DesignPatterns;

public interface IOrder
{
    string Describe();
    decimal Total();
}

public class BasicOrder : IOrder
{
    private string _item;
    private decimal _price;

    public BasicOrder(string item, decimal price)
    {
        _item = item;
        _price = price;
    }

    public string Describe() => _item;
    public decimal Total() => _price;
}

public abstract class OrderDecorator : IOrder
{
    protected readonly IOrder _inner;
    protected OrderDecorator(IOrder inner)
    {
        _inner = inner;
    }
    public virtual string Describe() => _inner.Describe();
    public virtual decimal Total() => _inner.Total();
}

public class GiftWrap : OrderDecorator
{
    public GiftWrap(IOrder inner) : base(inner){}
    public override string Describe() => _inner.Describe() + " + gift wrap";
    public override decimal Total() => _inner.Total() + 5m;
}

public class ExpressShipping : OrderDecorator
{
    public ExpressShipping(IOrder inner) : base(inner){}
    public override string Describe() => _inner.Describe() + " + express shipping";
    public override decimal Total() => _inner.Total() + 12m;
}

public class SalesTax : OrderDecorator
{
    private decimal _rate;
    public SalesTax(IOrder inner, decimal rate) : base(inner)
    {
        _rate = rate;
    }
    public override string Describe() => _inner.Describe() + " + sales tax";
    public override decimal Total() => _inner.Total() * _rate;
}

public class Order()
{
    static void Print(IOrder order)
    {
        Console.WriteLine($"{order.Describe()}: ${order.Total():F2}");
    }
    public static void Run()
    {
        IOrder order = new BasicOrder("Headphones", 80m);
        Print(order);

        order = new GiftWrap(order);
        Print(order);

        order = new ExpressShipping(order);
        Print(order);

        order = new SalesTax(order, 1.12m);
        Print(order);
    }
}