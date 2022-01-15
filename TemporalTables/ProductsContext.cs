using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalTables.Models;

namespace TemporalTables
{
    // Install-Package Microsoft.EntityFrameworkCore.SqlServer
    internal class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable(tableBuilder => tableBuilder.IsTemporal());
        }


    }
}
