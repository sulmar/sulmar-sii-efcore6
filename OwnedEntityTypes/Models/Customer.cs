using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnedEntityTypes.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address InvoiceAddress { get; set; }
        public Address ShipAddress { get; set; }

        public override string ToString() => $"{FirstName} {LastName} invoice: {InvoiceAddress} ship: {ShipAddress}";
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public override string ToString() => $"{ZipCode} {Street} {City} {Country}";
    }
}
