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

ControlTransactionTest(context);


static void ControlTransactionTest(TransactionContext context)
{
    decimal amount = 100;

    using var transaction = context.Database.BeginTransaction();
    Console.WriteLine($"Start transaction {transaction.TransactionId}");

    try
    {
        var sender = context.Accounts.Single(a => a.AccountNumber == "1111");
        sender.Balance -= amount;

        context.SaveChanges();

        var recipient = context.Accounts.Single(a => a.AccountNumber == "2222");
        recipient.Balance += amount;

        if (recipient.Balance > Account.BalanceLimit)
            throw new Exception($"Balance over limit {Account.BalanceLimit:C2}");

        context.SaveChanges();

        transaction.Commit();
        Console.WriteLine($"Commited transaction {transaction.TransactionId}");

    }
    catch (Exception ex)
    {
        transaction.Rollback();
        Console.WriteLine($"Rollbacked transaction {transaction.TransactionId}");
    }

}


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