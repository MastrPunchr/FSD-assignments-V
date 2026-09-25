namespace Banking.Core;

public abstract class BankAccount
{
    private readonly List<Transaction> _transactions = new();

    public List<Transaction> Transactions
    {
        get => _transactions;
    }

    private string _accountNumber = "";
    private decimal _balance;
    private Customer _owner;
    protected virtual decimal OverdraftLimit => 0m;
    public decimal AvailableFunds => Balance + OverdraftLimit;

    public string AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value;
    }
    
    public decimal Balance
    {
        get => _balance;
        private set => _balance = value;
    }

    public Customer Owner
    {
        get => _owner;
        set => _owner = value;
    }

    protected BankAccount(string accountNumber, Customer owner)
    {
        AccountNumber = accountNumber;
        Owner = owner;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0m)
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be greater than zero.");

        _balance += amount;
        PostTransaction(amount, "Deposit");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0m)
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be greater than zero.");

        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");

        _balance -= amount;
        PostTransaction(-amount, "Withdraw");
    }

    private protected void PostTransaction(decimal amount, string description)
    {
        Balance += amount;
        _transactions.Add(new Transaction(DateTime.UtcNow, amount, description, Balance));
    }
}

