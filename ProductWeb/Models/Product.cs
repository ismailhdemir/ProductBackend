namespace ProductWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreationDate { get; set; }
        public int ProductGroupId { get; set; }
    }
}
