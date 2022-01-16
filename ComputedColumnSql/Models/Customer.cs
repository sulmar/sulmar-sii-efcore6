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

        // public string FullName => $"{FirstName} {LastName}";
        public string FullName { get; set; } // ustawiane na podst. pola wyliczanego
        
        public decimal Balance { get; set; }    // ustawiane na podst. wartości domyślnej

        public DateTime CreatedOn { get; set; } // ustawiane na podst. funkcji SQL

        public DateTime ModifiedOn { get; set; } // ustawiane na podst. triggera

        

    }
}
