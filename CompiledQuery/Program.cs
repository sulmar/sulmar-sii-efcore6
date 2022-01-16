﻿using Bogus;
using CompiledQuery;
using CompiledQuery.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Compiled Query!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=VehiclesDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<VehicleContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new VehicleContext(options);

if (context.Database.EnsureCreated())
{
    var vehicles = new Faker<Vehicle>()
        .UseSeed(0)
        .RuleFor(p => p.Model, f => f.Vehicle.Model())
        .RuleFor(p => p.Make, f => f.Vehicle.Manufacturer())
        .RuleFor(p => p.VIN, f => f.Vehicle.Vin())
        .Generate(100_000);

    context.Vehicles.AddRange(vehicles);
    context.SaveChanges();
}

string vin = "QH50GG2YY8XY23970";

var foundVehicle = context.Vehicles.Single(v => v.VIN == vin);

Console.WriteLine(foundVehicle);

var foundVehicle2 = context.GetVehicleByVIN(vin);

Console.WriteLine(foundVehicle2);




