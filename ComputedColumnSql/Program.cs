using ComputedColumnSql;
using ComputedColumnSql.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Change Tracking!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ComputedColumnSqlDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<ComputedColumnSqlContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new ComputedColumnSqlContext(options);



if (context.Database.EnsureCreated())
{
    
    context.Database.ExecuteSqlRaw(@"
            CREATE TRIGGER [dbo].[Customer_UPDATE] ON [dbo].[Customers]
                AFTER UPDATE
            AS
            BEGIN
                SET NOCOUNT ON;

                IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                DECLARE @Id INT

                SELECT @Id = INSERTED.Id
                FROM INSERTED

                UPDATE dbo.Customers
                SET ModifiedOn = GETUTCDATE()
                WHERE Id = @Id
            END
");

    context.Customers.Add(new Customer { FirstName = "John", LastName = "Smith" });
    context.SaveChanges();
}

var customer = context.Customers.Find(1);

Console.WriteLine(customer);

customer.FirstName = "John";
customer.Balance += 100;

context.SaveChanges();

Console.WriteLine(customer);



