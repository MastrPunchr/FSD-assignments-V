namespace PaymentPlus;

public class BitcoinPayment : OnlinePayment
{
    public string WalletId { get; }

    public BitcoinPayment(string walletId, string paymentGateway, decimal amount,
        string currency) : base(paymentGateway, amount, currency)
    {
        WalletId = walletId;
    }

    public override void ProcessPayment()
    {
        Console.WriteLine("Bitcoin Payment successfully processed.");
    }

    public override void Authorize()
    {
        Console.WriteLine("Bitcoin Payment Authorized.");
    }

    public override void LogPayment()
    {
        base.LogPayment();
        Console.WriteLine("Type: Credit");
    }
}