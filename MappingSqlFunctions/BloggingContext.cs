using MappingSqlFunctions.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingSqlFunctions
{
    internal class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs  { get; set; }

        public BloggingContext(DbContextOptions options) : base(options)
        {
        }

        public int ActivePostCountForBlog(int blogId) => throw new NotSupportedException();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()              
                .Property(p => p.Id).HasColumnName("BlogId");

            modelBuilder.Entity<Post>()
                .ToTable("Posts")
                .Property(p => p.Id).HasColumnName("PostId");
                

            modelBuilder.Entity<Comment>()
                .ToTable("Comments")
                .Property(p => p.Id).HasColumnName("CommentId");


            modelBuilder.HasDbFunction(typeof(BloggingContext)
                .GetMethod(nameof(ActivePostCountForBlog), new[] { typeof(int) }))
                .HasName("CommentedPostCountForBlog");
        }

       


    }
}
