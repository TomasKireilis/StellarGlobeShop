using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using HotChocolate.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StellarGlobe.MyShop.GraphQl.ModelTypes;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.Database
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
            if (!_ctx.Shops.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Database/seedShops.json");
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
                var filePath = Path.Combine(_env.ContentRootPath, "Database/seedProducts.json");
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