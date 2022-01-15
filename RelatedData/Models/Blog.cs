using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatedData.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Blog : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Person Owner { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    public class Person : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Post : BaseEntity
    {
        public string Slug { get; set; }
        public string Content { get; set; }
        public byte Rating { get; set; }
        public Person Author { get; set; }

        public override string ToString() => $"[{Slug}] {new string('*', Rating)} \n {Content} \n";

    }
}
