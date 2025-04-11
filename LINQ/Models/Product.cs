namespace ECommerceApp.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
