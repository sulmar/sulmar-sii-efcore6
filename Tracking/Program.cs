// See https://aka.ms/new-console-template for more information
using Bogus;
using ChangeTracking;
using ChangeTracking.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Change Tracking!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ChangeTrackingDb";

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

var customer1 = new Customer { FirstName = "John", LastName = "Smith" };

//Console.WriteLine(context.Entry(customer1).State);

context.Customers.Add(customer1);

////Console.WriteLine(context.Entry(customer).State);

context.SaveChanges();

////Console.WriteLine(context.Entry(customer).State);

//// TODO: update customer

//// Utworzenie migawki (snapshot)
var customer = context.Customers.First();

Console.WriteLine(context.Entry(customer).State);

customer.FirstName = "Jack";

Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

//// context.Entry(customer).State = EntityState.Modified;

//var firstNameProperty = context.Entry(customer).Property(p => p.FirstName);
//var lastNameProperty = context.Entry(customer).Property(p => p.LastName);

//// lastNameProperty.IsModified = true;

//Console.WriteLine($"{firstNameProperty.OriginalValue} -> {firstNameProperty.CurrentValue} {firstNameProperty.IsModified}");
//Console.WriteLine($"{lastNameProperty.OriginalValue} -> {lastNameProperty.CurrentValue} {lastNameProperty.IsModified}");

//Console.WriteLine(context.Entry(customer).State);  // -> context.ChangeTracker.DetectChanges();

//if (context.ChangeTracker.HasChanges()) // -> context.ChangeTracker.DetectChanges();
//{

//}



//context.SaveChanges(); // -> context.ChangeTracker.DetectChanges();

//Console.WriteLine(context.Entry(customer).State);

// TODO: delete customer

//var customer = context.Customers.First();

//Console.WriteLine(context.Entry(customer).State);

//context.Customers.Remove(customer);
//Console.WriteLine(context.Entry(customer).State);

//context.SaveChanges();

//Console.WriteLine(context.Entry(customer).State);


// TODO: add order

// deserializacja

//var product = new Product { Id = 8 };
//var customer = new Customer { Id = 4 };

//var productDb = context.Products.Find(product.Id);
//var customerDb = context.Customers.Find(customer.Id);


//var order = new Order
//{
//    Customer = customer,
//    Details = new List<OrderDetail>
//    { 
//        new OrderDetail { Quantity = 5, Amount = 10, Product = product}
//    }
//};


// Ręczne sterowanie
//context.Entry(customer).State = EntityState.Unchanged;
//context.Entry(product).State = EntityState.Unchanged;

// Automatyczne sterowanie
//context.ChangeTracker.TrackGraph(order, node =>
//{
//    node.Entry.State = EntityState.Unchanged;

//    if (!node.Entry.IsKeySet)
//    {
//        node.Entry.State = EntityState.Added;
//    }

//    //if (node.Entry is OrderDetail)
//    //{
//    //    context.Entry(node.Entry).Property("Quantity").IsModified = true;
//    //}   

//    //if (node.Entry is Product && node.Entry.State == EntityState.Deleted)
//    //{
//    //    Product product = (Product)node.Entry.Entity;

//    //    node.Entry.State = EntityState.Unchanged;
//    //    product.IsRemoved = true;
//    //    context.Entry<Product>(product).Property(p=>p.IsRemoved).IsModified = true;

//    //}

//    // https://docs.microsoft.com/pl-pl/ef/core/saving/disconnected-entities
//});



//context.Orders.Add(order);

var entries = context.ChangeTracker.Entries().ToList();

foreach (var entity in entries)
{
    Console.WriteLine($"{entity.Entity} {entity.State}");
}


Console.WriteLine("ShortView");
Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

Console.WriteLine("LongView");
Console.WriteLine(context.ChangeTracker.DebugView.LongView);



context.SaveChanges();


// Remove
var p = new Product { Id = 10 };
context.Products.Remove(p);
context.SaveChanges();

// Wyłączenie śledzenia dla wszystkich obiektów
context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;

// Wyłączenie śledzenia dla zbioru obiektów
// var products = context.Products.AsNoTracking().ToList();

// var products = context.Products.AsNoTrackingWithIdentityResolution().ToList();