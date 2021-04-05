using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StellarGlobe.MyShop.Models
{
    public class Product
    {
        [Key] public Guid Id { get; set; }
        public string ProductTypeId { get; set; }
        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal SellingPrice { get; set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}