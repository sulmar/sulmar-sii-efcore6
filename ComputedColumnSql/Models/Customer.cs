using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputedColumnSql.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public decimal Balance { get; set; } // na podst. triggera

        // public string FullName => $"{FirstName} {LastName}";

    }
}
