namespace Banking.Core;

public class SavingsAccount : BankAccount
{
    private decimal _annualInterestRate;

    public decimal AnnualInterestRate
    {
        get => _annualInterestRate;
        set
        {
            if (value < 0m || value > 0.2m)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Rate must be between 0 and 0.02");
            }
        }
    }

    internal SavingsAccount(string accountNumber, Customer owner, decimal annualInterestRate) : base(accountNumber, owner)
    {
        AnnualInterestRate = annualInterestRate;
    }

    internal void ApplyMonthlyInterest()
    {
        if(Balance <= 0m)
            return;
        decimal interest = Math.Round(Balance * AnnualInterestRate / 12m, 2);
        PostTransaction(interest, "Monthly Interest");
    }

    protected override decimal OverdraftLimit => 500m;
}