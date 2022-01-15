// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Migrations;

Console.WriteLine("Hello, Migrations!");

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=OrdersDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer

var options = new DbContextOptionsBuilder<CustomersContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new CustomersContext(options);
