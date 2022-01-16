// See https://aka.ms/new-console-template for more information
using Bogus;
using ChangeTracking;
using ChangeTracking.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Change Tracking!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=PostsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<ChangeTrackingContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new ChangeTrackingContext(options);


if (context.Database.EnsureCreated())
{
    var products = new Faker<Product>()
        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
        .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
        .Generate(10);

    context.Products.AddRange(products);
    context.SaveChanges();
}


// TODO: add customer


// TODO: update customer


// TODO: delete customer


// TODO: add order