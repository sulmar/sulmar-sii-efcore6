using ComputedColumnSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputedColumnSql
{
    internal class ComputedColumnSqlContext : DbContext
    {
        public ComputedColumnSqlContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("FirstName + ' ' + LastName");

            modelBuilder.Entity<Customer>()
                .Property(p => p.Balance)                
                .ValueGeneratedOnAddOrUpdate();
        }

    }
}
