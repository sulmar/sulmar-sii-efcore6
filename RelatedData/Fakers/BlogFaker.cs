using Bogus;
using RelatedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatedData.Fakers
{
    internal class PostFaker : Faker<Post>
    {
        public PostFaker(Faker<Models.Person> personFaker)
        {
            RuleFor(p => p.Slug, f => f.Lorem.Slug());
            RuleFor(p => p.Content, f => f.Lorem.Text());
            RuleFor(p => p.Rating, f => f.Random.Byte(0, 5));
            RuleFor(p => p.Author, personFaker.Generate());
        }
    }

    internal class BlogFaker : Faker<Blog>
    {
        public BlogFaker(IEnumerable<Models.Person> people, Faker<Post> postFaker)
        {
            RuleFor(p => p.Title, f => f.Hacker.Noun());
            RuleFor(p => p.Owner, f => f.PickRandom(people));
            RuleFor(p => p.Posts, f => postFaker.GenerateBetween(1, 100).ToList());
        }
    }

    internal class PersonFaker : Faker<Models.Person>
    {
        public PersonFaker()
        {
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
        }
    }
}
