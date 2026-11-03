namespace DesignPatterns;

public interface ITicket
{
    decimal Price { get; }
    string Describe();
}

public class StandardTicket(decimal basePrice) : ITicket
{
    public decimal Price { get; } = basePrice;

    public string Describe() => $"Standard ticket: ${Price:F2}";
}

public class StudentTicket(decimal basePrice, int discountPercent) : ITicket
{
    public decimal Price { get; } = basePrice * (100 - discountPercent) / 100m;

    public string Describe() => $"Student ticket: ${Price:F2} ({discountPercent}% off)";
}

public class VipTicket(decimal basePrice, string lounge) : ITicket
{
    public decimal Price { get; } = basePrice * 3;

    public string Describe() => $"VIP ticket: ${Price:F2}, lounge access: {lounge}";
}

public class TicketFactory
{
    private decimal price = 20;
    public ITicket CreateTicket(string type)
    {
        return type switch
        {
            "standard" => new StandardTicket(price),
            "student" => new StudentTicket(price, 25),
            "vip" => new VipTicket(price, "North Lounge"),
            _ => throw new ArgumentException($"Unknown ticket type: {type}")
        };
    }
}

public class Ticket
{
    public static void Run()
    {
        TicketFactory factory = new TicketFactory();
        Console.WriteLine(factory.CreateTicket("standard").Describe());
        Console.WriteLine(factory.CreateTicket("student").Describe());
        Console.WriteLine(factory.CreateTicket("vip").Describe());
    }
}