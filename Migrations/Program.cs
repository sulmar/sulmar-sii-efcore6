// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Migrations;
using Migrations.Models;

Console.WriteLine("Hello, Migrations!");

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=CustomersDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer

//var identityOptions = new DbContextOptionsBuilder<IdentityDbContext>()
//    .UseSqlServer(connectionString)
//    .Options;

var options = new DbContextOptionsBuilder<CustomersContext>()
    .UseSqlServer(connectionString)
    .Options;


// using var identityContext = new ExtendedIdentityDbContext(identityOptions);
using var context = new CustomersContext(options);

//identityContext.Database.EnsureDeleted();
//identityContext.Database.EnsureCreated();

context.Database.Migrate();


//var user = new ApplicationUser { Id = "marcin", Login = "marcin", Password = "12345", AccountNumber = "1222" };
//var extendedUser = new ExtendedApplicationUser {  User = user, Email = "marcin.sulecki@sulmar.pl" };

//identityContext.ExtendedApplicationUsers.Add(extendedUser);
//identityContext.SaveChanges();

var customer = new Customer { Id = "john", FirstName = "John", LastName = "Smith", Pesel = "012345678911", Gender = Gender.Male };
context.Customers.Add(customer);
// context.Entry(customer.Owner).State = EntityState.Unchanged;

Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

context.SaveChanges();


// Install-Package Microsoft.EntityFrameworkCore.Tools


