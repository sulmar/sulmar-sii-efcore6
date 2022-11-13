using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


    }
}
