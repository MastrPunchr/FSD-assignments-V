namespace PaymentPlus;

public class CreditCardPayment : OnlinePayment
{   public string CardNumber { get; }
    public string ExpiryDate { get; }
    public int Cvv { get; }

    public CreditCardPayment(string cardNumber, string expiryDate, int cvv, string paymentGateway, decimal amount,
        string currency) : base(paymentGateway, amount, currency)
    {
        CardNumber = cardNumber;
        ExpiryDate = expiryDate;
        Cvv = cvv;
    }

    public override void ProcessPayment()
    {
        Console.WriteLine($"Type: Credit\nAmount: {Amount:C}");
    }

    public override bool ValidatePayment()
    {
        if (Currency == "EUR")
        {
            return Amount >= 10 && base.ValidatePayment();
        }
        return base.ValidatePayment();
    }

    public override void Authorize()
    {
        Console.WriteLine("Credit Card Payment Authorized.");
    }

    public override void LogPayment()
    {
        base.LogPayment();
        Console.WriteLine("Type: Credit");
    }
}