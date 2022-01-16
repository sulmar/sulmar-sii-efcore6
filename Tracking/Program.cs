// See https://aka.ms/new-console-template for more information
using ChangeTracking;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Change Tracking!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=PostsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<ChangeTrackingContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new ChangeTrackingContext(options);


context.Database.EnsureCreated();


// TODO: add customer


// TODO: update customer


// TODO: delete customer
