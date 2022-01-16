// See https://aka.ms/new-console-template for more information
using Bogus;
using Interceptors;
using Interceptors.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Interceptors!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=InterceptorsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<InterceptorsContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new InterceptorsContext(options);

if (context.Database.EnsureCreated())
{
    var customers = new Faker<Customer>()
        .RuleFor(p => p.FirstName, f => f.Person.FirstName)
        .RuleFor(p => p.LastName, f => f.Person.LastName)
        .Generate(100);

    context.Customers.AddRange(customers);
    context.SaveChanges();
}

