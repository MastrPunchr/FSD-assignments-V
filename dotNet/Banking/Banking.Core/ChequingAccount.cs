namespace Banking.Core;

public class ChequingAccount : BankAccount
{
    internal ChequingAccount(string accountNumber, Customer owner) : base(accountNumber, owner)
    {
        
    }

    protected override decimal OverdraftLimit => 500m;
}