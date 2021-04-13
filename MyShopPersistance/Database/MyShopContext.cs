namespace MyShopPersistance.Database
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
            modelBuilder.Entity<Product>()
                .HasKey(x => new { x.ShopId, x.ProductTypeName });
        }
    }
}