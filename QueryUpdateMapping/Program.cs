using Bogus;
using Microsoft.EntityFrameworkCore;
using QueryUpdateMapping;
using QueryUpdateMapping.Models;

Console.WriteLine("Hello, Query Update Mapping!");


string connectionString = @"Server=(localdb)\mssqllocaldb;Database=PostsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
var options = new DbContextOptionsBuilder<PostContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new PostContext(options);


if (context.Database.EnsureCreated())
{
    context.Database.ExecuteSqlRaw("CREATE VIEW PostsView AS SELECT TOP(10) * FROM Posts ORDER BY CreateDate desc");

    var posts = new Faker<Post>()
        .UseSeed(0)
        .RuleFor(p => p.Title, f => f.Lorem.Sentence())
        .RuleFor(p => p.Content, f => f.Lorem.Paragraphs())
        .RuleFor(p => p.Slug, f => f.Lorem.Slug())
        .RuleFor(p => p.CreateDate, f => f.Date.Past())
        .Generate(50);

    context.Set<Post>().AddRange(posts);
    context.SaveChanges();
}

var lastPosts = context.Set<Post>().ToList();

foreach (var item in lastPosts)
{
    Console.WriteLine(item);
}