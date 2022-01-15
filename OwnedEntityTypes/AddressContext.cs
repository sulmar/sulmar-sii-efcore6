using Microsoft.EntityFrameworkCore;
using OwnedEntityTypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnedEntityTypes
{

    internal class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .OwnsOne(p => p.InvoiceAddress);

            modelBuilder.Entity<Customer>()
                .OwnsOne(p => p.ShipAddress, address =>
                {
                    address.Ignore(p => p.Country);
                });

            modelBuilder.Entity<Customer>()
                .OwnsOne(p => p.Location);

            modelBuilder.Entity<Customer>()
                .Navigation(p => p.ShipAddress).IsRequired(false);

            modelBuilder.Entity<Customer>()
                .Navigation(p=>p.Location).IsRequired(false);
        }


    }
}
