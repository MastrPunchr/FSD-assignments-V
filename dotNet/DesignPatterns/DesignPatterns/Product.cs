namespace DesignPatterns;

public interface IPriceObserver
{
    void PriceChanged(string productName, decimal oldPrice, decimal newPrice);
}

public class EmailAlert : IPriceObserver
{
    private string _email;

    public EmailAlert(string email)
    {
        _email = email;
    }

    public void PriceChanged(string productName, decimal oldPrice, decimal newPrice)
    {
        if(newPrice < oldPrice)
            Console.WriteLine($"Email to {_email}: {productName} dropped from ${oldPrice} to ${newPrice}");
    }
}

public class PriceHistory : IPriceObserver
{
    public List<decimal> Prices { get; } = new List<decimal>();

    public void PriceChanged(string productName, decimal oldPrice, decimal newPrice)
    {
        Prices.Add(newPrice);
    }
}

public class Product
{
    private readonly List<IPriceObserver> _observers = new List<IPriceObserver>();
    private decimal _price;
    public string Name { get; }

    public Product(string name, decimal price)
    {
        Name = name;
        _price = price;
    }

    public void Subscrible(IPriceObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IPriceObserver observer) => _observers.Remove(observer);

    public decimal Price
    {
        get => _price;
        set
        {
            if (value == _price)
                return;
            decimal oldPrice = _price;
            _price = value;
            foreach (IPriceObserver observer in _observers)
            {
                observer.PriceChanged(Name, oldPrice, value);
            }
        }
    }
}