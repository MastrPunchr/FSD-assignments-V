namespace Banking.Core;

public class Bank
{
    private readonly Dictionary<string, BankAccount> _accounts = new();
    private int _nextAccountNumber = 1;

    public ChequingAccount OpenChequingAccount(Customer owner)
    {
        ChequingAccount c1 = new ChequingAccount(NextAccountNumber(), owner);
        _accounts.Add(c1.AccountNumber, c1);
        return c1;
    }

    public SavingsAccount OpenSavingsAccount(Customer owner, decimal inchRestRate)
    {
        SavingsAccount s1 = new SavingsAccount(NextAccountNumber(), owner, inchRestRate);
        _accounts.Add(s1.AccountNumber, s1);
        return s1;
    }

    public BankAccount? FindAccount(string accountNumber)
    {
        return _accounts.GetValueOrDefault(accountNumber);
    }

    public void ChangeSavingsRate(SavingsAccount account, decimal newRate)
    {
        account.AnnualInterestRate = newRate;
    }

    public void RunMonthEnd()
    {
        foreach(SavingsAccount savingsAccount in _accounts.Values.OfType<SavingsAccount>())
            savingsAccount.ApplyMonthlyInterest();
    }

    private string NextAccountNumber()
    {
        string number = AccountNumberFormatter.Format(_nextAccountNumber);
        _nextAccountNumber++;
        return number;
    }
}

file static class AccountNumberFormatter
{
    public static string Format(int sequence) => $"ACC-{sequence:D6}";
}