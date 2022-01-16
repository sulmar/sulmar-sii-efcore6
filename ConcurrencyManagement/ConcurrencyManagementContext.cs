using ConcurrencyManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyManagement
{
    internal class ConcurrencyManagementContext : DbContext
    {
        public ConcurrencyManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(p=>p.Balance)
                .IsConcurrencyToken();

            modelBuilder.Entity<Customer>()
                .Property(p => p.FirstName)
                .IsConcurrencyToken();

            modelBuilder.Entity<Customer>()
                .Property(p => p.LastName)
                .IsConcurrencyToken();
        }
    }
}
