﻿using Bogus;
using Inheritance.Models;

namespace Inheritance.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            Ignore(p => p.Id);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.Weight, f => f.Random.Float(1, 1000));
            RuleFor(p => p.Color, f => f.Commerce.Color());
        }
    }
}
