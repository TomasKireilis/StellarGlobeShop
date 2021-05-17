using System;
using Microsoft.EntityFrameworkCore;
using MyShop.Persistance.Database;

namespace MyShop.Persistance.Migrations
{
    [DbContext(typeof(MyShopContext))]
    partial class MyShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StellarGlobe.MyShop.Application.Models.Product", b =>
                {
                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductTypeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("SellingQuantity")
                        .HasColumnType("int");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ShopId", "ProductTypeName");

                    b.HasIndex("ProductTypeName");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StellarGlobe.MyShop.Application.Models.ProductType", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("StellarGlobe.MyShop.Application.Models.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("StellarGlobe.MyShop.Application.Models.Product", b =>
                {
                    b.HasOne("StellarGlobe.MyShop.Application.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StellarGlobe.MyShop.Application.Models.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("StellarGlobe.MyShop.Application.Models.Shop", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}