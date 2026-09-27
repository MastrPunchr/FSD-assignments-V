namespace PaymentPlus;

public class ChequePayment : OfflinePayment
{
    public int ChequeNumber { get; }
    public string BankName { get;  }

    public ChequePayment(int chequeNumber, string bankName, decimal amount, string currency) : base(amount, currency)
    {
        ChequeNumber = chequeNumber;
        BankName = bankName;
    }

    public override void ProcessPayment()
    {
       Console.WriteLine("Cheque Payment successfully processed");
    }

    public override bool ValidatePayment()
    {
        if(Currency == "CAD")
            return base.ValidatePayment();
        return Amount % 1 == 0;
    }

    public override void RecordPayment()
    {
        Console.WriteLine("Cheque Payment was recorded.");
    }
}