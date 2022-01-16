namespace ChangeTracking.Models
{
    public class OrderDetail : BaseEntity
    {        
        public Product Product { get; set; }
        public byte Quantity { get; set; }
        public decimal Amount { get; set; }        
    }
}
