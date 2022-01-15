using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalTables.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }

        public Product(string name, decimal price, string color)
        {
            Name = name;
            Price = price;
            Color = color;
        }

        public override string ToString() => $"{Id} {Name} {Price:C2}";
    }
}
