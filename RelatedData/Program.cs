// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using RelatedData;
using RelatedData.Fakers;
using RelatedData.Models;

Console.WriteLine("Hello, Related Data!");




string connectionString = @"Server=(localdb)\mssqllocaldb;Database=BlogsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer

// Install-Package Microsoft.EntityFrameworkCore.Proxies
var options = new DbContextOptionsBuilder<BlogContext>()
    .UseSqlServer(connectionString)
  //  .UseLazyLoadingProxies()
    .Options;

using var context = new BlogContext(options);

//if (!context.Blogs.Any())
//{
// var blogs = GenerateBlogs();
//    context.Database.EnsureDeleted();
//    context.Database.EnsureCreated();

//    context.Blogs.AddRange(blogs);
//    context.SaveChanges();
//}

// Eager loading (zachłanne pobieranie danych)
//var allBlogs = context.Blogs
//    .Include(b=>b.Owner)
//    .Include(p=>p.Posts.Where(p=>p.Rating > 3))
//        .ThenInclude(p=>p.Author)
//    .ToList();

//Display(allBlogs);

// Explicit Loading (jawne pobieranie danych)

var blogs2 = context.Blogs.ToList();

//foreach (var blog in blogs2)
//{
//    Console.WriteLine(blog.Title);

//    context.Entry(blog).Reference(p => p.Owner).Load();
//    Console.WriteLine(blog.Owner.FirstName);

//    context.Entry(blog).Collection(p => p.Posts).Load();

//    foreach (var post in blog.Posts)
//    {
//        context.Entry(post).Reference(p => p.Author).Load();

//        Console.WriteLine(post);
//    }    
//}

// Lazy loading - z użyciem Proxy
// Lazy loading - z użyciem LazyLoader

var blogs3 = context.Blogs.ToList();

foreach (var blog in blogs2)
{
    Console.WriteLine(blog.Title);

    Console.WriteLine(blog.Owner.FirstName);

    foreach (var post in blog.Posts)
    {
        Console.WriteLine(post);
    }
}

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