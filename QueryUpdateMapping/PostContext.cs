using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryUpdateMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryUpdateMapping
{

    public class PostContext : DbContext
    {     

        public PostContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }


    }

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .ToTable("Posts")
                // .ToView("PostsView")
                .ToSqlQuery(@"SELECT TOP(5) * FROM Posts ORDER BY CreateDate desc")
               // .ToFunction("")
                ;
        }
    }
}
