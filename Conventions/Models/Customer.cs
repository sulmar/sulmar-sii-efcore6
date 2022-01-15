using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conventions.Models
{
    public abstract class Base
    {
        
    }

    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class Customer : BaseEntity
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
    }

    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }

    public class OrderDetail : BaseEntity
    {
        public Product Product { get; set; }
        public byte Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsRemoved { get; set; }
    }
}
