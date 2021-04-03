using Microsoft.EntityFrameworkCore;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.Database
{
    public class MyShopContext : DbContext
    {
        public MyShopContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Shop>()
            //    .HasMany(p => p.Products)
            //    .WithOne(p => p.Shop!)
            //    .HasForeignKey(p => p.);

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Shop)
            //    .WithMany(p => p.Products)
            //    .HasForeignKey(p => p.ProductId);
        }
    }
}