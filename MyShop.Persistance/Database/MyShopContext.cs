using Microsoft.EntityFrameworkCore;
using MyShop.Persistance.Products;
using MyShop.Persistance.ProductSlots;

namespace MyShop.Persistance.Database
{
    public class MyShopContext : DbContext
    {
        public MyShopContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSlot> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .HasKey(x => new { x.ShopId, x.ProductTypeName });
        }
    }
}