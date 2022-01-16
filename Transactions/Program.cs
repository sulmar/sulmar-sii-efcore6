// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Transactions;
using Transactions.Models;

Console.WriteLine("Hello, Transactions!");

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=TransactionsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<TransactionContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new TransactionContext(options);

if (context.Database.EnsureCreated())
{
    var accounts = GenerateAccounts();
    context.Accounts.AddRange(accounts);
    context.SaveChanges();
}

// TODO: safe transfer money

decimal amount = 100;

var sender = context.Accounts.Single(a => a.AccountNumber == "1111");
sender.Balance -= amount;

context.SaveChanges();

var recipient = context.Accounts.Single(a => a.AccountNumber == "2222");
recipient.Balance += amount;

context.SaveChanges();


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