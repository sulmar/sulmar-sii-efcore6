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

var customer = new Customer { FirstName = "John", LastName = "Smith" };

if (context.Database.EnsureCreated())
{
    context.Customers.Add(customer);
    context.SaveChanges();
}

customer.FirstName = "Jack";

Console.WriteLine(customer.FullName);

context.SaveChanges();



