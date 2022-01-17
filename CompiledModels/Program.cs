
using Bogus;
using CompiledModels;
using CompiledModels.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Compiled Models!");


// Compiled Models - od wersji EF Core 6
// W przypadku gdy posiadamy bardzo duży model i uruchamianie EF Core jest wolne bardzo warto wygenerować skompilowane modele:

// 1. Kompilacja modeli
// CLI: dotnet ef dbcontext optimize -c CompiledModelsContext -o CompliledModels -n CompiledModels
// PMC: Optimize-DbContext -Context CompiledModelsContext -OutputDir CompiledModels -Namespace CompiledModels

// 2. Użycie skompilowanych modeli
// options.UseModel(CompiledModels.CompiledModelsContextModel.Instance);

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=CompiledModelsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<CompiledModelsContext>()
    .UseSqlServer(connectionString)
    .UseModel(CompiledModels.CompiledModelsContextModel.Instance)
    .Options;

using var context = new CompiledModelsContext(options);


if (context.Database.EnsureCreated())
{
    var customers = new Faker<Customer>()
        .RuleFor(p => p.FirstName, f => f.Person.FirstName)
        .RuleFor(p => p.LastName, f => f.Person.LastName)
        .Generate(10);

    context.Customers.AddRange(customers);
    context.SaveChanges();
}