// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using TemporalTables;
using TemporalTables.Models;

Console.WriteLine("Hello, TemporalTables!");

var products = GenerateProducts();

Display(products);


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ProductsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<ProductsContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new ProductsContext(options);


//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();

//context.Products.AddRange(products);
//context.SaveChanges();

// TODO: Change price
var product = context.Products.SingleOrDefault(p => p.Name == "DeLorean");

product.Price = 800_000;

context.SaveChanges();


// TODO: Get current price
var currentPrice = context.Products.Single(p => p.Name == "DeLorean").Price;

Console.WriteLine(currentPrice);

// TODO: Get historical prices
var historical = context.Products.TemporalAll()
        .OrderBy(p=>EF.Property<DateTime>(p, "PeriodStart"))
        .Where(p=>p.Name == "DeLorean")
        .Select(p=>new
        {
            Product = p,
            PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
            PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),
        })
        .ToList();

foreach (var item in historical)
{
    Console.WriteLine($"{item.Product} {item.PeriodStart} - {item.PeriodEnd}");
}



// TODO: Get price on date

DateTime on = DateTime.Parse("2022-01-15 15:21");

var productOnDate = context.Products.TemporalAsOf(on)
    .Single(p => p.Name == "DeLorean");

Console.WriteLine(productOnDate);

Console.ReadLine();

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