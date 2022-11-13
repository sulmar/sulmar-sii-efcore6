// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using TableSplitting;
using TableSplitting.Models;

Console.WriteLine("Hello, World!");

// var attachments = GenerateAttachments();
var attachments = GenerateAttachmentHeaders();

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=AttachmentsDb";

// Install-Package Microsoft.EntityFrameworkCore.SqlServer

// Install-Package Microsoft.EntityFrameworkCore.Proxies
var options = new DbContextOptionsBuilder<AttachmentContext>()
    .UseSqlServer(connectionString)
    .Options;


using var context = new AttachmentContext(options);

if (!context.AttachmentHeaders.Any())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();


    // TODO: save attachments to database
    context.AttachmentHeaders.AddRange(attachments);
    context.SaveChanges();
}


// TODO: get attachments without content
var query = context.AttachmentHeaders.ToList();

// Display(query);

// TODO: get content attachment with content

var attachment = context.AttachmentContents.Find(1);

// get attachment headers with content
var query2 = context.AttachmentHeaders.Include(p => p.Content).ToList();

Console.WriteLine(attachment);



static void Display(IEnumerable<Attachment> attachments)
{
    foreach (var attachment in attachments)
    {
        Console.WriteLine(attachment);
    }
}


static IEnumerable<Attachment> GenerateAttachments()
{

    var attachments = new List<Attachment>
    {
        new Attachment { ContentType = "application/pdf",
            Title = "Hello World!",
            Description = "Lorem ipsum",
            FileName = Path.GetFileName(@"Assets\hello-world.pdf"),
            
        },

        new Attachment { ContentType = "image/png",
            Title = "EFCore",
            Description = "Lorem ipsum",
            FileName = Path.GetFileName(@"Assets\efcore.png"),
            Content = File.ReadAllBytes(@"Assets\efcore.png")
        },
    };

    return attachments;
}

static IEnumerable<AttachmentHeader> GenerateAttachmentHeaders()
{
    var attachments = new List<AttachmentHeader>
    {
        new AttachmentHeader {
            Title = "Hello World!",
            Description = "Lorem ipsum",
            FileName = Path.GetFileName(@"Assets\hello-world.pdf"),

            Content = new AttachmentContent
            {
                ContentType = "application/pdf",
                FileName = Path.GetFileName(@"Assets\hello-world.pdf"),
                Content = File.ReadAllBytes(@"Assets\hello-world.pdf")
            }
        },

        new AttachmentHeader {
            Title = "EFCore",
            Description = "Lorem ipsum",
            FileName = Path.GetFileName(@"Assets\efcore.png"),

            Content = new AttachmentContent {
            ContentType = "image/png",
            FileName = Path.GetFileName(@"Assets\efcore.png"),
            Content = File.ReadAllBytes(@"Assets\efcore.png")
            }
        }
    };

    return attachments;
}