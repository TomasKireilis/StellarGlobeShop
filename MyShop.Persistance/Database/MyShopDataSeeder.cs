using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MyShop.Persistance.Products;
using MyShop.Persistance.ProductTypes;
using MyShop.Persistance.Shops;

namespace MyShop.Persistance.Database
{
    public class MyShopDataSeeder
    {
        private readonly MyShopContext _ctx;
        private readonly IWebHostEnvironment _env;

        public MyShopDataSeeder(IWebHostEnvironment env, IDbContextFactory<MyShopContext> ctx)
        {
            _env = env;
            _ctx = ctx.CreateDbContext();
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if (!_ctx.ProductTypes.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Setup/seedProductTypes.json");
                var json = File.ReadAllText(filePath);
                var productTypes = JsonSerializer.Deserialize<IEnumerable<ProductType>>(json);
                if (productTypes != null)
                {
                    _ctx.ProductTypes.AddRange(productTypes);
                    _ctx.SaveChanges();
                }
            }
            if (!_ctx.Shops.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Setup/seedShops.json");
                var json = File.ReadAllText(filePath);
                var shops = JsonSerializer.Deserialize<IEnumerable<Shop>>(json);
                if (shops != null)
                {
                    _ctx.Shops.AddRange(shops);
                    _ctx.SaveChanges();
                }
            }
            if (!_ctx.Products.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Setup/seedProducts.json");
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
                if (products != null)
                {
                    _ctx.Products.AddRange(products);
                    _ctx.SaveChanges();
                }
            }
        }
    }
}