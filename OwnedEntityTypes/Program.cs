// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using OwnedEntityTypes;
using OwnedEntityTypes.Models;

Console.WriteLine("Hello, Owned Entity Types!");

var customers = GenerateCustomers();

Display(customers);

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=AddressDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer

// Install-Package Microsoft.EntityFrameworkCore.Proxies
var options = new DbContextOptionsBuilder<AddressContext>()
    .UseSqlServer(connectionString)
    .Options;


using var context = new AddressContext(options);

context.Database.EnsureDeleted();
context.Database.EnsureCreated();   

// TODO: save customers to database
context.Customers.AddRange(customers);
context.SaveChanges();

// TODO: get customers from database
var customersDb = context.Customers.ToList();

static void Display(IEnumerable<Customer> customersDb)
{
    foreach (var customer in customersDb)
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
            FirstName = "John", LastName = "Smith",
            InvoiceAddress = new Address
            {
                City = "Warsaw",
                Country = "Poland",
                Street = "Puławska",
                ZipCode = "01-001"
            },

            Location = new Coordinate(52.05, 25.04),

            ShipAddress = new Address
            {
                City = "Warsaw",
                Country = "Poland",
                Street = "Puławska",
                ZipCode = "01-001"
            },
        },

        new Customer
        {
            FirstName = "Jack",
            LastName = "London",

           // Location = new Coordinate(51.95, 24.14),

            InvoiceAddress = new Address
            {
                City = "Bydgoszcz",
                Country = "Poland",
                Street = "Dworcowa",
                ZipCode = "85-138"
            },

            ShipAddress = new Address
            {
                City = "Poznań",
                Country = "Poland",
                Street = "Grunwaldzka",
                ZipCode = "60-166"
            }
        },


    };

    return customers;



}