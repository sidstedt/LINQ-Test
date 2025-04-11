using ECommerceApp.Models;
using static System.Net.WebRequestMethods;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ECommerceApp.DataAccess
{
    public class ProductDataAccess
    {
        // Dependency Injection
        private readonly ECommerceContext _context;

        // Constructor
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
            foreach (var product in products)
            {
                Console.WriteLine($"Namn: {product.Name}\nPris: {product.Price}:-");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ListSuppliersWithLowStock()
        {
            var suppliers = _context.Products
                .Where(p => p.StockQuantity < 10)
                .Include(p => p.Supplier)
                .Select(p => new
                {
                    SupplierName = p.Supplier.Name,
                    SupplierEmail = p.Supplier.Email,
                    SupplierPhone = p.Supplier.Phone,
                    ProductName = p.Name
                })
                .OrderByDescending(p => p.SupplierName);
            string supplierName = "";
            foreach (var supplier in suppliers)
            {
                if (supplierName != supplier.SupplierName)
                {
                    Console.WriteLine($"\nLeverantör: {supplier.SupplierName}\n" +
                        $"Email: {supplier.SupplierEmail}\n" +
                        $"Telefonnr: {supplier.SupplierPhone}" +
                        $"Produkter med lågt lagersaldo:");
                    Console.WriteLine($"Produkt: {supplier.ProductName}");
                    supplierName = supplier.SupplierName;
                }
                else
                {
                    Console.WriteLine($"Produkt: {supplier.ProductName}");
                }
            }
        }

        public void CalculateAllOrderValue()
        {
            var totalOrderValue = _context.Orders
                .Where(o => o.OrderDate >= DateTime.Now.AddMonths(-1))
                .Sum(o => o.TotalAmount);

            Console.WriteLine($"\nTotala ordervärdet för den senaste månaden är: {totalOrderValue}");
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

        public void ListProductsInCategory()
        {
            var query = _context.Categories
                .GroupJoin(
                _context.Products,
                c => c.Id,
                p => p.CategoryId,
                (c, p) => new
                {
                    CategoryName = c.Name,
                    Products = p
                        .Select(p => p.Name)
                })
                .OrderBy(c => c.CategoryName);

            foreach (var category in query)
            {
                Console.WriteLine($"\n----{category.CategoryName}----");
                foreach (var product in category.Products)
                {
                    Console.WriteLine($"Namn: {product}");
                }
            }
        }

        public void GetAllOrders()
        {

            var orders = _context.Orders
                .Where(o => o.TotalAmount > 1000)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .Include(o => o.Customer)
                .Select(o => new
                {
                    CustomerName = o.Customer.Name,
                    CustomerEmail = o.Customer.Email,
                    CustomerPhone = o.Customer.Phone,
                    CustomerAddress = o.Customer.Address,
                    OrderInfo = o.OrderDetails.Select(od => new
                    {
                        od.Product.Name,
                        od.Quantity,
                        od.Product.Price,
                    })
                });

            foreach (var order in orders)
            {
                Console.WriteLine($"\nNamn: {order.CustomerName} " +
                    $"\nAdress: {order.CustomerAddress}" +
                    $"\nEmail: {order.CustomerEmail}" +
                    $"\nTelefon: {order.CustomerPhone}");
                foreach (var orderInfo in order.OrderInfo)
                {
                    Console.WriteLine($"Produktnamn: {orderInfo.Name} " +
                        $"\nAntal: {orderInfo.Quantity}" +
                        $"\nPris: {orderInfo.Price}");
                }
            }

            //- [X] Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris(högst först)
            //- [X] Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
            //- [X] Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
            //- [X] Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
            //- [X] Lista alla kategorier och antalet produkter i varje kategori
            //- [X] Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
        }
    }
}
