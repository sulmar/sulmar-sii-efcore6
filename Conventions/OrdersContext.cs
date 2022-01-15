using Conventions.Configurations;
using Conventions.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conventions
{
    // Install-Package Microsoft.EntityFrameworkCore.SqlServer
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();

        // EF Core 6 PreConfiguration
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(200);
            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");                        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            //modelBuilder.Properties<DateTime>()
            //.Configure(c => c.SetColumnType("datetime"));

            //modelBuilder.Properties()
            //  .Where(p => p.Name == p.DeclaringType.Name + "Id")
            //  .Configure(c => c.IsKey());



        }

      

    }
}
