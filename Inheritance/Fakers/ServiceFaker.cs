using Bogus;
using Inheritance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Fakers
{

    public class ServiceFaker : Faker<Service>
    {
        public ServiceFaker()
        {
            Ignore(p => p.Id);
            RuleFor(p => p.Name, f => f.Hacker.Verb());
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.Duration, f => TimeSpan.FromMinutes(60));
        }
    }
}
