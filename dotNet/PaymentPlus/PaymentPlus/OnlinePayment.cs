namespace PaymentPlus;

public abstract class OnlinePayment : Payment
{
    private string _paymentGateway;

    internal OnlinePayment(string paymentGateway, decimal amount, string currency) : base(amount, currency)
    {
        _paymentGateway = paymentGateway;
    }

    public abstract override void ProcessPayment();

    public override bool ValidatePayment()
    {
        return Amount > 5 && base.ValidatePayment(); 
    }

    public abstract void Authorize();
}