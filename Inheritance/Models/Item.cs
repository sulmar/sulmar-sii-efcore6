using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{

    public abstract class Item : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class Product : Item
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public float Weight { get; set; }
    }

    public class Service : Item
    {
        public TimeSpan Duration { get; set; }
    }


}
