namespace DesignPatterns;

public interface IDiscountStrategy
{
    decimal Apply(decimal subtotal);
}

public class NoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal subtotal) => subtotal;
}

public class PercentageDiscount : IDiscountStrategy
{
    private int _percent;

    public PercentageDiscount(int percent)
    {
        _percent = percent;
    }

    public decimal Apply(decimal subtotal) => subtotal * (100 - _percent) / 100m;
}

public class FixedDiscount : IDiscountStrategy
{
    private int _amount;

    public FixedDiscount(int amount)
    {
        _amount = amount;
    }

    public decimal Apply(decimal subtotal) => subtotal - _amount;
}


public class Checkout
{
    public IDiscountStrategy Discount { get; set; }

    public Checkout(IDiscountStrategy discount)
    {
        Discount = discount;
    }

    public decimal Total(decimal subtotal) => Discount.Apply(subtotal);
}