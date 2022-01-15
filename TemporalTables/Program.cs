// See https://aka.ms/new-console-template for more information
using TemporalTables.Models;

Console.WriteLine("Hello, TemporalTables!");

var products = GenerateProducts();

Display(products);

// TODO: Change price

// TODO: Get current price

// TODO: Get historical prices

// TODO: Get price on date


static void Display(IEnumerable<Product> items)
{
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static IEnumerable<Product> GenerateProducts()
{
    var products = new List<Product>
    {
        new("DeLorean", 1_000_000m, "Red"),
        new("Landrover", 500_000m, "Green"),
        new("Jeep", 10_000m, "Black"),
    };

    return products;
}