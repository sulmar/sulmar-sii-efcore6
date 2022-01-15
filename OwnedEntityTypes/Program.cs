// See https://aka.ms/new-console-template for more information
using OwnedEntityTypes.Models;

Console.WriteLine("Hello, Owned Entity Types!");

var customers = GenerateCustomers();

Display(customers);

// TODO: save customers to database

// TODO: get customers from database


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
            FirstName = "John", LastName = "Smith",
            InvoiceAddress = new Address
            {
                City = "Warsaw",
                Country = "Poland",
                Street = "Puławska",
                ZipCode = "01-001"
            },

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