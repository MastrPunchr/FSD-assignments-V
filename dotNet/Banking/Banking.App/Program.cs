using Banking.Core;

var account = new BankAccount("ACC-000001");
account.Deposit(100m);

Console.WriteLine(account.GetBalance());
try
{
    account.Withdraw(5000m);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
