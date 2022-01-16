// See https://aka.ms/new-console-template for more information
using ConcurrencyManagement;
using ConcurrencyManagement.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Concurrency Managament!");

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ConcurrencyManagamentDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<ConcurrencyManagementContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new ConcurrencyManagementContext(options);

if (context.Database.EnsureCreated())
{
    var customer = new Customer { FirstName = "John", LastName = "Smith", Balance = 1000 };
    context.Customers.Add(customer);
    context.SaveChanges();
}

// 1. Jack
using var jackContext = new ConcurrencyManagementContext(options);

var customer1 = jackContext.Customers.Find(1);
// customer1.Balance = 2000;
customer1.FirstName = "Bob";

// 2. Anna
using var annaContext = new ConcurrencyManagementContext(options);

var customer2 = annaContext.Customers.Find(1);
// customer2.Balance = 500;
customer2.FirstName = "Robert";
annaContext.SaveChanges();

Thread.Sleep(TimeSpan.FromSeconds(5));

try
{
    jackContext.SaveChanges();
}
catch(DbUpdateConcurrencyException e)
{    
    Console.WriteLine("Dane zostały w międzyczasie zmienione:");
    var entities = e.Entries.ToList();

    foreach (var entry in entities)
    {
        Console.WriteLine(entry.Entity);

        // Odświeżenie encji z bazy danych
        entry.Reload();


    }

    
}