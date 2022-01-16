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

        /*

        CREATE FUNCTION dbo.CommentedPostCountForBlog(@id int)
            RETURNS int
            AS
            BEGIN
                RETURN (SELECT COUNT(*)
                    FROM [Posts] AS [p]
                    WHERE ([p].[BlogId] = @id) AND ((
                        SELECT COUNT(*)
                        FROM [Comments] AS [c]
                        WHERE [p].[PostId] = [c].[PostId]) > 0));
            END
        */

        public int ActivePostCountForBlog(int blogId) => throw new NotSupportedException();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(BloggingContext)
                .GetMethod(nameof(ActivePostCountForBlog), new[] { typeof(int) }))
                .HasName("CommentedPostCountForBlog");
        }

        /*
         var query1 = from b in context.Blogs
             where context.ActivePostCountForBlog(b.BlogId) > 1
             select b;

        */


    }
}
