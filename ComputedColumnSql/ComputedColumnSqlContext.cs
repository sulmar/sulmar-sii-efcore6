using ComputedColumnSql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            modelBuilder.ApplyConfiguration(new CustomerConfigurarion());
        }

    }

    public class CustomerConfigurarion : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
               .Property(p => p.FullName)
               .HasComputedColumnSql("FirstName + ' ' + LastName");

            // Domyślna wartość
            builder
                .Property(p => p.Balance)
                .HasDefaultValue(1000m);

            // Domyślna wartość pola na podstawie funkcji
            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            // Wartość na podstawie triggera
            builder
                .Property(p => p.ModifiedOn)
                .ValueGeneratedOnUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }
    }
}
