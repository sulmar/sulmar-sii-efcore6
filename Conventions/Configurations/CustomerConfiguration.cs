using Conventions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conventions.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(p => p.Id)
                .HasColumnName("CustomerId");

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50);

            builder
             .Property(p => p.Pesel)
             .HasMaxLength(11)
             .IsUnicode(false)
             .IsFixedLength();
        }
    }
}
