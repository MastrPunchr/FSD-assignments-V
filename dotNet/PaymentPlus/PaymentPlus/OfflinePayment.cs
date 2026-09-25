namespace PaymentPlus;

public abstract class OfflinePayment : Payment
{
    internal OfflinePayment(string paymentType, decimal amount, string currency) : base(amount, currency)
    {
        
    }

    public abstract override void ProcessPayment();

    public abstract void RecordPayment();
}