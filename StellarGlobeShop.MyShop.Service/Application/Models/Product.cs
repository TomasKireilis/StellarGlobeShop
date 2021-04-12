using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StellarGlobeShop.MyShop.Service.Application.Models
{
    public class Product
    {
        public string ProductTypeName { get; set; }
        public ProductType ProductType { get; set; }
        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal SellingPrice { get; set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}