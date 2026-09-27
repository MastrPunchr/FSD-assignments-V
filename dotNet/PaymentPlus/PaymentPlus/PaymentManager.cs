namespace PaymentPlus;

public class PaymentManager
{
    private List<Payment> _payments = new List<Payment>();
    
    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public void ValidatePayments()
    {
        foreach (Payment payment in _payments)
        {
            if (payment.ValidatePayment()) return;
            switch (payment)
            {
                //TO-DO: dis shi
                case BitcoinPayment:
                    break;
                case CashPayment:
                    break;
                case ChequePayment:
                    break;
                case CreditCardPayment:
                    break;
            }
        }
    }

    public void AuthorizePayments()
    {
        foreach (OnlinePayment payment in _payments.OfType<OnlinePayment>())
        {
            payment.Authorize();
        }
    }

    public void RecordOffline()
    {
        foreach (OfflinePayment payment in _payments.OfType<OfflinePayment>())
        {
            payment.RecordPayment();
        }
    }

    public void ProcessPayments()
    {
        foreach (Payment payment in _payments)
        {
            payment.ProcessPayment();
        }
    }
}