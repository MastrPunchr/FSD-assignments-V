namespace DesignPatterns;

public class Program
{
    public static void Main()
    {
        Notification.Run();
        Ticket.Run();
        Report.Run();

        PizzaBuilder pb1 = new PizzaBuilder();
        Pizza p1 = pb1
            .WithSize(14)
            .WithDough("Thin")
            .AddTopping("Pepperoni")
            .WithExtraCheese()
            .Build();
        Console.WriteLine(p1);
        
        Order.Run();

        NoDiscount discount = new NoDiscount();
        Checkout checkout = new Checkout(discount);
        checkout.Discount = new PercentageDiscount(10);

        Product headphones = new Product("Headphones", 80m);
        EmailAlert alertP1 = new EmailAlert("alan@example.com");
        EmailAlert alertP2 = new EmailAlert("alice@example.com");
        PriceHistory history = new PriceHistory();
        
        headphones.Subscrible(alertP1);
        headphones.Subscrible(alertP2);
        headphones.Price = 70m;
        headphones.Price = 75m;
        headphones.Price = 75m;
        
        headphones.Unsubscribe(alertP1);
        headphones.Price = 60m;
        
        Console.WriteLine(string.Join(", ", history.Prices)); 
    }
}