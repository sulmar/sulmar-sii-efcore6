﻿// See https://aka.ms/new-console-template for more information
using Conversions;
using Conversions.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Conversions!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ConversionsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<ConversionsContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new ConversionsContext(options);

if (context.Database.EnsureCreated())
{
    context.Customers.AddRange(GenerateCustomers());
    context.SaveChanges();
}

// TODO: get customers from database

var customers = context.Customers.ToList();

Display(customers);


static void Display(IEnumerable<Customer> customers)
{
    foreach (var customer in customers)
    {
        Console.WriteLine(customer);
    }
}

static IEnumerable<Customer> GenerateCustomers()
{

    var customers = new List<Customer>
    {
        new Customer
        {
            FirstName = "John", LastName = "Smith", MembershipType = MembershipType.Free,
             Location = new Coordinate(52.01, 21.05),
            Profile = new Profile { Theme = "Dark", Volume = 50 },
            DateOfBirth = new DateOnly(1990, 5, 1),
            WakeupHour = new TimeOnly(7, 30),
            CanSend = true
        },

        new Customer 
        { 
            FirstName = "Jack", LastName = "London", MembershipType = MembershipType.Premium,
             Location = new Coordinate(51.21, 20.65),
            Profile = new Profile { Theme = "Light", Volume = 10 },
            DateOfBirth = new DateOnly(1980, 1, 20),
            WakeupHour = new TimeOnly(6, 0)
        }
    };

    return customers;

    
       
}

