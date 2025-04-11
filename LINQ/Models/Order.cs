namespace ECommerceApp.Models
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int TotalAmount { get; set; }
        public bool Status { get; set; }

        // Navigation Properties
        public Customer? Customer { get; set; } = null;
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
