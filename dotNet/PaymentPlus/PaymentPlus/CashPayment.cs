namespace PaymentPlus;

public class CashPayment : OfflinePayment
{
    public CashPayment(decimal amount, string currency) : base(amount, currency) { }
    
    public override void ProcessPayment()
    {
        Console.WriteLine($"Cash Payment successfully processed.");
    }

    public override bool ValidatePayment()
    {
        return Currency != "EUR";
    }

    public override void RecordPayment()
    {
        Console.WriteLine("Cash Payment was recorded");
    }
}