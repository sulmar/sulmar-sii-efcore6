namespace ChangeTracking.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
