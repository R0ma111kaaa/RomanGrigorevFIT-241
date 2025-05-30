using System;
using System.Collections.Generic;
using System.Linq;

class Supplier
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Phone { get; set; }
}

class Product
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
}

class ProductMovement
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public required string Prefix { get; set; } // "Поступление" или "Продажа"
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

class Program
{
    static void Main()
    {
        // Данные
        var suppliers = new List<Supplier>
        {
            new Supplier { Id = 1, Name = "елабуга", Phone = "69-69-69" },
            new Supplier { Id = 2, Name = "автоматика сервис", Phone = "789-101" }
        };

        var products = new List<Product>
        {
            new Product { ProductId = 1, Name = "шахед" },
            new Product { ProductId = 2, Name = "обычный бпла" }
        };

        var movements = new List<ProductMovement>
        {
            new ProductMovement { ProductId = 1, SupplierId = 1, Prefix = "Поступление", Date = new DateTime(2024, 5, 1), Quantity = 100, UnitPrice = 10 },
            new ProductMovement { ProductId = 1, SupplierId = 1, Prefix = "Продажа", Date = new DateTime(2024, 5, 3), Quantity = 30, UnitPrice = 15 },
            new ProductMovement { ProductId = 2, SupplierId = 2, Prefix = "Поступление", Date = new DateTime(2024, 5, 2), Quantity = 50, UnitPrice = 20 },
            new ProductMovement { ProductId = 2, SupplierId = 2, Prefix = "Продажа", Date = new DateTime(2024, 5, 4), Quantity = 10, UnitPrice = 25 },
        };

        // 1. Остатки товаров
        Console.WriteLine("1. Остатки товаров:\n");

        var stock = movements
            .GroupBy(m => m.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                ProductName = products.First(p => p.ProductId == g.Key).Name,
                Quantity = g.Sum(m => m.Prefix == "Поступление" ? m.Quantity : -m.Quantity)
            });

        foreach (var item in stock)
        {
            Console.WriteLine($"{item.ProductName}: {item.Quantity} шт.");
        }

        // 2. Товары сгруппированные по поставщикам (только поставки)
        Console.WriteLine("\n2. Поставленные товары по поставщикам:\n");

        var suppliesBySupplier = movements
            .Where(m => m.Prefix == "Поступление")
            .GroupBy(m => m.SupplierId)
            .Select(g => new
            {
                SupplierName = suppliers.First(s => s.Id == g.Key).Name,
                Products = g.Select(m => products.First(p => p.ProductId == m.ProductId).Name).Distinct()
            });

        foreach (var group in suppliesBySupplier)
        {
            Console.WriteLine($"Поставщик: {group.SupplierName}");
            foreach (var product in group.Products)
            {
                Console.WriteLine($"  - {product}");
            }
        }

        // 3. Продажи по дате
        Console.WriteLine("\n3. Продажи по дате:\n");

        var salesByDate = movements
            .Where(m => m.Prefix == "Продажа")
            .GroupBy(m => m.Date)
            .Select(g => new
            {
                Date = g.Key,
                Products = g.Select(m => new
                {
                    ProductName = products.First(p => p.ProductId == m.ProductId).Name,
                    Quantity = m.Quantity,
                    Price = m.UnitPrice
                })
            });

        foreach (var sale in salesByDate.OrderBy(s => s.Date))
        {
            Console.WriteLine($"Дата: {sale.Date.ToShortDateString()}");
            foreach (var product in sale.Products)
            {
                Console.WriteLine($"  - {product.ProductName}, Кол-во: {product.Quantity}, Цена: {product.Price}");
            }
        }
    }
}
