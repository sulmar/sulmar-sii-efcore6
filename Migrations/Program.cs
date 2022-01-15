// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Migrations;
using Migrations.Models;

Console.WriteLine("Hello, Migrations!");

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=CustomersDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer

var identityOptions = new DbContextOptionsBuilder<IdentityDbContext>()
    .UseSqlServer(connectionString)
    .Options;

var options = new DbContextOptionsBuilder<CustomersContext>()
    .UseSqlServer(connectionString)
    .Options;


using var identityContext = new IdentityDbContext(identityOptions);
using var context = new CustomersContext(options);

identityContext.Database.EnsureDeleted();
identityContext.Database.EnsureCreated();
context.Database.Migrate();


var user = new ApplicationUser { Id = "marcin", Login = "marcin", Password = "12345", AccountNumber = "1222" };

identityContext.ApplicationUsers.Add(user);
identityContext.SaveChanges();

context.Customers.Add(new Customer { Id = "john", FirstName = "John", LastName = "Smith", Owner = user });

Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

context.SaveChanges();


// Install-Package Microsoft.EntityFrameworkCore.Tools


