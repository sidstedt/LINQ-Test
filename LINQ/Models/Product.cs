namespace ECommerceApp.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public Category Category { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
