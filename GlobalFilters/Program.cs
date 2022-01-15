// See https://aka.ms/new-console-template for more information
using Bogus;
using GlobalFilters;
using GlobalFilters.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=GlobalFiltersDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<GlobalFilterContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new GlobalFilterContext(options);

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var customers = new Faker<Customer>()
    .RuleFor(p => p.FirstName, f => f.Person.FirstName)
    .RuleFor(p => p.LastName, f => f.Person.LastName)
    .RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f))
    .Generate(100);

context.Customers.AddRange(customers);
context.SaveChanges();

var activeCustomers = context.Customers.ToList();



foreach (var item in activeCustomers)
{
    Console.WriteLine(item);
}

var allCustomers = context.Customers.IgnoreQueryFilters().ToList();

foreach (var item in allCustomers)
{
    Console.WriteLine(item);
}


