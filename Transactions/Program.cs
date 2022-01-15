// See https://aka.ms/new-console-template for more information
using Transactions.Models;

Console.WriteLine("Hello, Transactions!");

// TODO: safe transfer money


static void Display(IEnumerable<Account> accounts)
{
    foreach (var account in accounts)
    {
        Console.WriteLine(account);
    }
}

static IEnumerable<Account> GenerateAccounts()
{
    var accounts = new List<Account>
    {
        new Account { AccountNumber = "1111", Balance = 1000 },
        new Account { AccountNumber = "2222", Balance = 1000 }
    };

    return accounts;
}