namespace Banking.Core;

public class SavingAccount : BankAccount
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

    internal SavingAccount(string accountNumber, Customer owner, decimal annualInterestRate) : base(accountNumber, owner)
    {
        AnnualInterestRate = annualInterestRate;
    }

    protected override decimal OverdraftLimit => 500m;
}