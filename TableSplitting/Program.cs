// See https://aka.ms/new-console-template for more information
using TableSplitting.Models;

Console.WriteLine("Hello, World!");

var attachments = GenerateAttachments();

Display(attachments);

// TODO: save customers to database

// TODO: get attachments without content

// TODO: get attachments with content



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
            FileName = Path.GetFileName(@"Assets\hello-world.pdf"), 
            Content = File.ReadAllBytes(@"Assets\hello-world.pdf") 
        },

        new Attachment { ContentType = "image/png",
            FileName = Path.GetFileName(@"Assets\efcore.png"),
            Content = File.ReadAllBytes(@"Assets\efcore.png")
        },
    };

    return attachments;
}