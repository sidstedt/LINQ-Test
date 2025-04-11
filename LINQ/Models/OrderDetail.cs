﻿namespace ECommerceApp.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

        // Navigation Properties
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
