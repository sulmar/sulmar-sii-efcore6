using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryUpdateMapping.Models;

namespace QueryUpdateMapping
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .ToTable("Posts")
                // .ToView("PostsView")
                .ToSqlQuery(@"SELECT TOP(5) * FROM Posts ORDER BY CreateDate desc")
                .ToFunction("")
                ;
        }
    }
}
