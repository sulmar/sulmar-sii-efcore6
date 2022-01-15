// See https://aka.ms/new-console-template for more information
using RelatedData.Fakers;
using RelatedData.Models;

Console.WriteLine("Hello, Related Data!");

var customers = GenerateBlogs();

Display(customers);

// TODO: save blogs to database

// TODO: Eager loading 

// TODO: Explicit Loading

// TODO: Lazy loading





static IEnumerable<Blog> GenerateBlogs()
{
    var personFaker = new PersonFaker();

    var authors = personFaker.Generate(5);

    var faker = new BlogFaker(authors, new PostFaker(personFaker));

    var blogs = faker.Generate(10);

    return blogs;
}

static void Display(IEnumerable<Blog> blogs)
{
    foreach (var blog in blogs)
    {
        Console.WriteLine(blog);

        foreach (var post in blog.Posts)
        {
            Console.WriteLine(post);
        }
    }
}