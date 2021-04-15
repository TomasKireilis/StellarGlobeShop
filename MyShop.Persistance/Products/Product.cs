using System;
using System.ComponentModel.DataAnnotations.Schema;
using MyShop.Persistance.ProductTypes;
using MyShop.Persistance.Shops;

namespace MyShop.Persistance.Products
{
    public class Product : IEntity
    {
        public string ProductTypeName { get; set; }
        public ProductType ProductType { get; set; }
        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal SellingPrice { get; set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
        public Guid Id { get; set; }
    }
}