using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MyShop.Persistance.Products;

namespace MyShop.Persistance.Database
{
    public class MyShopDataSeeder
    {
        private readonly MyShopContext _ctx;

        public MyShopDataSeeder(IDbContextFactory<MyShopContext> ctx)
        {
            _ctx = ctx.CreateDbContext();
        }

        public void Seed()
        {
            Console.WriteLine("Seeding not implemented");
            //_ctx.Database.EnsureCreated();
            //if (!_ctx.ProductTypes.Any())
            //{
            //    var filePath = Path.Combine(_env.ContentRootPath, "Setup/seedProductTypes.json");
            //    var json = File.ReadAllText(filePath);
            //    var productTypes = JsonSerializer.Deserialize<IEnumerable<ProductType>>(json);
            //    if (productTypes != null)
            //    {
            //        _ctx.ProductTypes.AddRange(productTypes);
            //        _ctx.SaveChanges();
            //    }
            //}

            //if (!_ctx.Products.Any())
            //{
            //    var filePath = Path.Combine(_env.ContentRootPath, "Setup/seedProducts.json");
            //    var json = File.ReadAllText(filePath);
            //    var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
            //    if (products != null)
            //    {
            //        _ctx.Products.AddRange(products);
            //        _ctx.SaveChanges();
            //    }
            //}
        }
    }
}