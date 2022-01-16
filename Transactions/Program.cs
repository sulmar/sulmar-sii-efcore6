using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Transactions;
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

// SingleContextControlTransactionTest(context);

// MultiContextControlTransactionTest(options);

// MultiContextControlDistributedTransactionTest(options);

ExternalTransactionTest();

static void ExternalTransactionTest()
{
    decimal amount = 100;

    string connectionString = @"Server=(localdb)\mssqllocaldb;Database=TransactionsDb";
    using var connection = new SqlConnection(connectionString);
    connection.Open();

    using var transaction = connection.BeginTransaction();

    try
    {
        var command = connection.CreateCommand();
        command.Transaction = transaction;  // <-- 
        command.CommandText = "UPDATE Accounts SET Balance = Balance + 100";
        command.ExecuteNonQuery();

        var options = new DbContextOptionsBuilder<TransactionContext>()
            .UseSqlServer(connection)
            .Options;

        using var context = new TransactionContext(options);
        context.Database.UseTransaction(transaction); // <--

        var recipient = context.Accounts.Single(a => a.AccountNumber == "1111");
        recipient.Balance += amount;
        context.SaveChanges();

        if (recipient.Balance > Account.BalanceLimit)
            throw new Exception($"Balance over limit {Account.BalanceLimit:C2}");

        transaction.Commit();

    }
    catch(Exception ex)
    {
        transaction.Rollback();
    }
   
    

}


static void SingleContextControlTransactionTest(TransactionContext context)
{
    decimal amount = 100;

    using var transaction = context.Database.BeginTransaction(); // SQL: BEGIN TRANSACTION
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

        transaction.Commit(); // SQL: COMMIT
        Console.WriteLine($"Commited transaction {transaction.TransactionId}");

    }
    catch (Exception ex)
    {
        transaction.Rollback(); // SQL: ROLLBACK
        Console.WriteLine($"Rollbacked transaction {transaction.TransactionId}");
    }

}

static void MultiContextControlTransactionTest(DbContextOptions options)
{
    decimal amount = 100;

    using var senderContext = new TransactionContext(options);
    using var transaction = senderContext.Database.BeginTransaction(); // SQL: BEGIN TRANSACTION
    Console.WriteLine($"Start transaction {transaction.TransactionId}");

    SqlConnection senderConnection = senderContext.Database.GetDbConnection() as SqlConnection;
    Console.WriteLine($"Sender Client Connection Id {senderConnection.ClientConnectionId}");

    try
    {
        var sender = senderContext.Accounts.Single(a => a.AccountNumber == "1111");
        sender.Balance -= amount;

        senderContext.SaveChanges();

        using var recipientContext = new TransactionContext(options);

        SqlConnection recipientConnection = recipientContext.Database.GetDbConnection() as SqlConnection;
        Console.WriteLine($"Recipient Client Connection Id {senderConnection.ClientConnectionId}");

        recipientContext.Database.UseTransaction(transaction.GetDbTransaction());

        var recipient = recipientContext.Accounts.Single(a => a.AccountNumber == "2222");
        recipient.Balance += amount;

        recipientContext.SaveChanges();

        if (recipient.Balance > Account.BalanceLimit)
            throw new Exception($"Balance over limit {Account.BalanceLimit:C2}");        

        transaction.Commit(); // SQL: COMMIT
        Console.WriteLine($"Commited transaction {transaction.TransactionId}");

    }
    catch (Exception ex)
    {
        transaction.Rollback(); // SQL: ROLLBACK
        Console.WriteLine($"Rollbacked transaction {transaction.TransactionId}");
    }

}

static void MultiContextControlDistributedTransactionTest(DbContextOptions options)
{
    decimal amount = 100;

    using var senderContext = new TransactionContext(options);

    // using var transaction = senderContext.Database.BeginTransaction(); // SQL: BEGIN TRANSACTION
    // Console.WriteLine($"Start transaction {transaction.TransactionId}");

    SqlConnection senderConnection = senderContext.Database.GetDbConnection() as SqlConnection;
    Console.WriteLine($"Sender Client Connection Id {senderConnection.ClientConnectionId}");

    try
    {
        using (var transaction = new TransactionScope())
        {
            var sender = senderContext.Accounts.Single(a => a.AccountNumber == "1111");
            sender.Balance -= amount;

            senderContext.SaveChanges();

            using var recipientContext = new TransactionContext(options);

            SqlConnection recipientConnection = recipientContext.Database.GetDbConnection() as SqlConnection;
            Console.WriteLine($"Recipient Client Connection Id {senderConnection.ClientConnectionId}");

            var recipient = recipientContext.Accounts.Single(a => a.AccountNumber == "2222");
            recipient.Balance += amount;

            recipientContext.SaveChanges();

            if (recipient.Balance > Account.BalanceLimit)
                throw new Exception($"Balance over limit {Account.BalanceLimit:C2}");

           // transaction.Complete();
            
        }  // --> IDisposable.Dispose() i zależnie od flagi jest Commit lub Rollback

    }
    catch (Exception ex)
    {        
        Console.WriteLine($"Rollbacked transaction");
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