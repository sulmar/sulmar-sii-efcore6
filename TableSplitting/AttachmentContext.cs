using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableSplitting.Models;

namespace TableSplitting
{
    internal class AttachmentContext : DbContext
    {
        public AttachmentContext(DbContextOptions options) : base(options)
        {
        }

        // public DbSet<Attachment> Attachments { get; set; }

        public DbSet<AttachmentHeader> AttachmentHeaders { get; set; }
        public DbSet<AttachmentContent> AttachmentContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttachmentHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentContentConfiguration());
        }

    }

    internal class AttachmentHeaderConfiguration : IEntityTypeConfiguration<AttachmentHeader>
    {
        public void Configure(EntityTypeBuilder<AttachmentHeader> builder)
        {
            builder.HasOne(p => p.Content)
                .WithOne()
                .HasForeignKey<AttachmentContent>(p => p.Id);

            builder.ToTable("Attachments");

            builder.Property(p => p.FileName)
                .HasColumnName(nameof(AttachmentHeader.FileName));
        }
    }

    internal class AttachmentContentConfiguration : IEntityTypeConfiguration<AttachmentContent>
    {
        public void Configure(EntityTypeBuilder<AttachmentContent> builder)
        {
            builder.ToTable("Attachments");

            builder.Property(p => p.FileName)
                 .HasColumnName(nameof(AttachmentHeader.FileName));
        }
    }
}
