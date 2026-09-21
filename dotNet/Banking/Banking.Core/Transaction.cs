namespace Banking.Core;

public class Transaction
{
    public DateTime Timestamp { get; }
    public decimal Amount { get; }
    public string Description { get; }
    public decimal BalanceAfter { get; }

    internal Transaction(DateTime timestamp, decimal amount, string description, decimal balanceAfter)
    {
        
    }
}