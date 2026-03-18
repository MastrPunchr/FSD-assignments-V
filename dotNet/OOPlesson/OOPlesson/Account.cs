namespace OOPlesson;

public class Account
{
    private string accountNumber;
    public string ownerName;
    private double balance;

    public Account(string accountHolder)
    {
        Random rnd = new Random();
        this.accountNumber = Convert.ToString(rnd.Next(0, 1000001));
        this.ownerName = accountHolder;
        this.balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            this.balance += amount;
        else
            Console.WriteLine("Amount should be positive\n");
    }

    public void Withdraw(double amount)
    {
        if (amount <= this.balance && amount > 0)
            this.balance -= amount;
        else
            Console.WriteLine("Invalid amount\n");
    }

    public string GetBalance()
    {
        return $"Balance: ${balance}\n";
    }

    public override string ToString()
    {
        return $"Account Number: {accountNumber}, Account Holder: {ownerName}";
    }
}