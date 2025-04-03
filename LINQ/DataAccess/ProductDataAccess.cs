using ECommerceApp.Models;
using static System.Net.WebRequestMethods;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ECommerceApp.DataAccess
{
    public class ProductDataAccess
    {
        private readonly ECommerceContext _context;

        public ProductDataAccess(ECommerceContext context)
        {
            _context = context;
        }
        public void ListAllProducts()
        {
            var products = _context.Categories
                .Where(c => c.Name == "Electronics")
                .SelectMany(p => p.Products)
                .OrderByDescending(p => p.Price);
            Console.WriteLine("--------------------------------------");
            foreach(var product in products)
            {
                Console.WriteLine($"Namn: {product.Name}\nPris: {product.Price}:-");
                Console.WriteLine("--------------------------------------");
            }
        }
        
        public void ListSuppliersWithLowStock()
        {
            var suppliers = _context.Suppliers
                .Where(s => _context.Products
                .Any(p => p.SupplierId == s.Id && p.StockQuantity < 10));

            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"Namn: {supplier.Name}\nEmail: {supplier.Email}\nTelefonnr: {supplier.Phone}");
                Console.WriteLine("-------------------------------------");
            }
        }

        public void CalculateAllOrderValue()
        {
            var totalOrderValue = _context.Orders
                .Where(o => o.OrderDate >= DateTime.Now.AddMonths(-1))
                .Sum(o => o.TotalAmount);

            Console.WriteLine($"Totala ordervärdet för den senaste månaden är: {totalOrderValue}");
        }

        public void ThreeMostSoldProducts()
        {

            var products = _context.OrderDetails
                .GroupBy(o => o.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalQuantity = g.Sum(o => o.Quantity)
                })
            .OrderByDescending(p => p.TotalQuantity)
            .Take(3)
            .Join(_context.Products, od => od.ProductId, p => p.Id, (od, p) => new
            {
                p.Name,
                od.TotalQuantity
            });

            foreach (var product in products)
            {
                Console.WriteLine($"\nNamn: {product.Name}\nSålda enheter:{product.TotalQuantity}");
                Console.WriteLine("--------------------------------------");
            }
        }

        //- [X] Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris(högst först)
        //- [X] Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
        //- [X] Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
        //- [ ] Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        //- [ ] Lista alla kategorier och antalet produkter i varje kategori
        //- [ ] Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
    }
}
