using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryUpdateMapping.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }

        public override string ToString() => $"[{Slug}] {Title} {Content} {CreateDate}";

    }
}
