namespace ChangeTracking.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }
}
