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
        foreach (Payment payment in _payments.ToList())
        {
            if (!payment.ValidatePayment())
            {
                switch (payment)
                {
                    //TO-DO: dis shi
                    case BitcoinPayment bitcoinPayment:
                        Console.WriteLine(
                            $"BTC Payment of {bitcoinPayment.Amount} {bitcoinPayment.Currency} from WalletID {bitcoinPayment.WalletId} through {bitcoinPayment.PaymentGateway} gateway was not valid, hence removed from the list.");
                        _payments.Remove(payment);
                        break;
                    case CashPayment cashPayment:
                        Console.WriteLine(
                            $"Cash Payment of {cashPayment.Amount} {cashPayment.Currency} was not valid, hence removed from the list.");
                        _payments.Remove(payment);
                        break;
                    case ChequePayment chequePayment:
                        Console.WriteLine(
                            $"Cheque Payment of {chequePayment.Amount} {chequePayment.Currency} with cheque number {chequePayment.ChequeNumber} from Bank {chequePayment.BankName} was not valid, hence removed from the list.");
                        _payments.Remove(payment);
                        break;
                    case CreditCardPayment cardPayment:
                        Console.WriteLine(
                            $"Credit Card Payment of {cardPayment.Amount} {cardPayment.Currency} from Credit Card number **** **** **** {cardPayment.CardNumber.Substring(cardPayment.CardNumber.Length - 4)} through {cardPayment.PaymentGateway} gateway was not valid, hence removed from the list.");
                        _payments.Remove(payment);
                        break;
                }
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