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
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}