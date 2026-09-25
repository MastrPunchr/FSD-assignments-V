using Banking.Core;

Bank bank = new Bank();

Customer alice = new Customer
{
    FirstName = "Alice",
    LastName = "Nguyen",
    Email = "alice@example.com"
};

ChequingAccount c1 = bank.OpenChequingAccount(alice);
SavingsAccount s1 = bank.OpenSavingsAccount(alice, 0.2m);

c1.Deposit(200m);
s1.Deposit(1_000m);
try
{
    c1.Withdraw(600m);
}
catch (Exception ex)
{
    Console.WriteLine($"Insufficient funds.", ex.Message);
}
bank.RunMonthEnd();
foreach (Transaction transaction in c1.Transactions)
{
    Console.WriteLine(transaction);
}
