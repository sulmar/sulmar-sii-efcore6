using Microsoft.EntityFrameworkCore;
using Migrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class ExtendedIdentityDbContext : IdentityDbContext
    {
        public DbSet<ExtendedApplicationUser> ExtendedApplicationUsers { get; set; }

        public ExtendedIdentityDbContext(DbContextOptions options) : base(options)
        {
        }        
    }

    public class ExtendedApplicationUser
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Email { get; set; }
    }


    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers", t => t.ExcludeFromMigrations());
        }




    }
}
