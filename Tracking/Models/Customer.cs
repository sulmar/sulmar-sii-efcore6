using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTracking.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }


    // POCO (Plain Old CLR Object)
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
