// =====================================================================
// DEMO STAGE 0 - The monolith
// One method does everything: validation, tax, payment, receipt, email.
// Hook activity: for each change request on the slide, circle every
// line you would have to edit.
// =====================================================================

using System.Net.Sockets;

namespace Solid_Principles;

public class OrderItem
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; } = "";
    public string Province { get; set; } = "MB";
    public string PaymentType { get; set; } = "Credit";   // "Credit", "Debit", "PayPal"
    public List<OrderItem> Items { get; } = new();
}

public abstract class PaymentMethod
{
    public abstract string Name { get; }
    public abstract decimal CalculateFee(decimal amount);
    
    //Shared behaviour lives in the base class.
    public decimal Charge(decimal amount)
    {
        decimal fee = CalculateFee(amount);
        Console.WriteLine($"[{Name}] Charging {amount + fee}");
        return fee;
    }
}

public class CreditCardPayment : PaymentMethod
{
    public override string Name => "Visa/MC gateway";

    public override decimal CalculateFee(decimal amount) => Math.Round(amount * 0.029m, 2);
}

public class DebitCardPayment : PaymentMethod
{
    public override string Name => "Interac debit";

    public override decimal CalculateFee(decimal amount) => Math.Round(amount * 0.035m, 2) + 0.30m;
}

public class PayPalPayment : PaymentMethod
{
    public override string Name => "PayPal API";

    public override decimal CalculateFee(decimal amount) => Math.Round(amount * 0.035m, 2) + 0.30m;
}

public class ApplePayPayment : PaymentMethod
{
    public override string Name => "Apple Pay";
    public override decimal CalculateFee(decimal amount) => Math.Round(amount * 0.015m, 2);
}

public class OrderValidator
{
    public void Validate(Order order)
    {
        if (order.Items.Count == 0)
            throw new ArgumentException("Order has no items.");
        if (!order.CustomerEmail.Contains('@'))
            throw new ArgumentException("Invalid email address.");
    }
}

public class TaxCalculator
{
    public decimal Subtotal(Order order)
    {
        decimal subtotal = 0;
        foreach (var item in order.Items) 
            subtotal += item.Price * item.Quantity;
        return subtotal;
    }

    public decimal Tax(decimal subtotal, string province)
    {
        decimal taxRate;
        if (province == "MB") taxRate = 0.12m;       // 5% GST + 7% PST
        else if (province == "ON") taxRate = 0.13m;  // HST
        else taxRate = 0.05m;                              // GST only
        decimal tax = Math.Round(subtotal * taxRate, 2);
        return tax;
    }
}

public class ReceiptWriter
{
    public void PrintReceipt(int id, decimal subtotal, decimal tax, decimal fee, decimal total)
    {
        string receipt = $"Order #{id} | Subtotal {subtotal:C} | Tax {tax:C} | Fee {fee:C} | Total {total:C}";
        Console.WriteLine($"[File] receipt_{id}.txt -> {receipt}");
    }
}

public class EmailNotifier
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[SMTP] To: {to} | {message}");
    }
}

public class CheckoutService
{
    private readonly OrderValidator _validator = new();
    private readonly TaxCalculator _tax = new();
    private readonly ReceiptWriter _printer = new();
    private readonly EmailNotifier _email = new();
    public void ProcessOrder(Order order, PaymentMethod payment)
    {
        // ---- 1. Validate --------------------------------------------
        _validator.Validate(order);

        // ---- 2. Subtotal and tax ------------------------------------

        decimal subtotal = _tax.Subtotal(order);
        decimal tax = _tax.Tax(subtotal, order.Province);

        // ---- 3. Charge the customer ---------------------------------
        decimal fee = payment.Charge(subtotal + tax);
        decimal total = subtotal + tax + fee;

        // ---- 4. Save a receipt --------------------------------------
        _printer.PrintReceipt(order.Id, subtotal, tax, fee, total);

        // ---- 5. Email the customer ----------------------------------
        _email.Send(order.CustomerEmail, $"Thanks for your order! Total: {total:C}");
    }
}

public static class Stage0Demo
{
    public static Order SampleOrder(string paymentType = "Credit") => new()
    {
        Id = 1001,
        CustomerEmail = "sam@example.com",
        Province = "MB",
        PaymentType = paymentType,
        Items =
        {
            new OrderItem { Name = "Keyboard", Price = 89.99m, Quantity = 1 },
            new OrderItem { Name = "USB-C cable", Price = 12.50m, Quantity = 2 },
        }
    };

    public static void Main()
    {
        var checkout = new CheckoutService();
        var order = SampleOrder();

        PaymentMethod[] methods =
        {
            new CreditCardPayment(), new DebitCardPayment(), new PayPalPayment(), new ApplePayPayment()
        };

        foreach (var method in methods)
        {
            checkout.ProcessOrder(order, method);
            Console.WriteLine();
        }
    }
}
