using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingSqlFunctions.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; } 

    }

    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
