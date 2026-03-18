namespace OOPlesson;

public class Bank
{
    private string bankName;
    private List<Account> accounts;
    private Account openAccount;

    public Bank(string bankName, string ownerName)
    {
        this.bankName = bankName;
        this.accounts = new List<Account>();
        this.openAccount = new Account(ownerName);
    }

    public void ChangeAccount()
    {
        Console.WriteLine("Enter the name of the account to switch to: ");
        string changeAccount = Console.ReadLine();
        openAccount = accounts[accounts.FindIndex(e => e.ownerName == changeAccount)];
        Console.WriteLine($"Active account changed to {changeAccount}!");
    }
    
    public void AddAccount()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        accounts.Add(new Account(name));
        openAccount = accounts[^1];
        Console.WriteLine($"Account {name} added!\n");
    }

    public void RemoveAccount()
    {
        Console.WriteLine("Account to remove:");
        string removeAccount = Console.ReadLine();
        int accountIndex = accounts.FindIndex(e => e.ownerName == removeAccount);
        accounts.Remove(accounts[accountIndex]);
        Console.WriteLine($"{removeAccount} removed!\n");
    }

    public void AddMoney()
    {
        Console.WriteLine("Enter amount to deposit:");
        double amount = Convert.ToDouble(Console.ReadLine());
        openAccount.Deposit(amount);
        Console.WriteLine($"${amount} deposited to account.");
    }

    public void RemoveMoney()
    {
        Console.WriteLine("Enter amount to withdraw:");
        double amount = Convert.ToDouble(Console.ReadLine());
        openAccount.Withdraw(amount);
        Console.WriteLine($"${amount} withdrawn.");
    }

    public void BankUI()
    {
        int userInput = 0;
        while (userInput != 8)
        {
            Console.WriteLine("______             _    _   _ _____ \n| ___ \\           | |  | | | |_   _|\n| |_/ / __ _ _ __ | | _| | | | | |  \n| ___ \\/ _` | '_ \\| |/ / | | | | |  \n| |_/ / (_| | | | |   <| |_| |_| |_ \n\\____/ \\__,_|_| |_|_|\\_\\\\___/ \\___/ ");
            Console.WriteLine($"\x1b[1mWelcome to {bankName}!\x1b[0m\n-------------------\n\n\nCurrent Account: {openAccount.ownerName}\n\n1. Display accounts\n2. Change account\n3. Add Account\n4. Remove account\n5. View balance\n6. Deposit\n7. Withdraw\n8. Exit\n\nEnter number:");
            userInput = Convert.ToInt16(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    foreach (Account ac in accounts)
                    {
                        Console.WriteLine(ac.ToString());
                    }
                    break;
                case 2:
                    ChangeAccount();
                    break;
                case 3:
                    AddAccount();
                    break;
                case 4:
                    RemoveAccount();
                    break;
                case 5:
                    openAccount.GetBalance();
                    break;
                case 6:
                    AddMoney();
                    break;
                case 7:
                    RemoveMoney();
                    break;
                default:
                    Console.WriteLine("Not a valid input, try again.");
                    break;
            
            }
        }
        Console.WriteLine("Thank you for using BankUI!");
    }
}