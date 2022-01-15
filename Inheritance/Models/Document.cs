namespace Inheritance.Models
{
    public abstract class Document : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Invoice : Document
    {
        public DateTime DueDate { get; set; }
    }

    public class Bill : Document
    {

    }
}
