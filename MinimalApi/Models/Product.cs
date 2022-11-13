namespace MinimalApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private decimal Price { get; set; }
    }
}
