﻿namespace ECommerceApp.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Phone { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
