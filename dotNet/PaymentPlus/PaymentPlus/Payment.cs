namespace PaymentPlus;

public abstract class Payment
{
    public decimal Amount;
    public string Currency;

    public Payment(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public abstract void ProcessPayment();

    public virtual bool ValidatePayment()
    {
        return Amount % 1 != 0.99m;
    }

    public virtual void LogPayment()
    {
        Console.WriteLine($"Amount: {Amount:C}\nCurrency: {Currency}");
    }
}