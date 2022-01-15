using Conventions;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Conventions!");

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=OrdersDb";

var options = new DbContextOptionsBuilder<OrdersContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new OrdersContext(options);

context.Database.EnsureDeleted();
context.Database.EnsureCreated();





