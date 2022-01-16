using ChangeTracking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTracking
{
    public class ChangeTrackingContext : DbContext
    {
        public ChangeTrackingContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot);

            // modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override int SaveChanges()
        {
            var updatedProducts = ChangeTracker.Entries<Product>()
                .Where(p => p.State == EntityState.Modified)
                .ToList();

            foreach (var entity in updatedProducts)
            {
                entity.Property(p => p.LastUpdated).CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }

    }
}
