using ComputedColumnSql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

            // Domyślna wartość
            modelBuilder.Entity<Customer>()
                .Property(p => p.Balance)
                .HasDefaultValue(1000m);

            // Domyślna wartość pola na podstawie funkcji
            modelBuilder.Entity<Customer>()
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            // Wartość na podstawie triggera
            modelBuilder.Entity<Customer>().Property(p => p.ModifiedOn)
                .ValueGeneratedOnUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }

    }
}
