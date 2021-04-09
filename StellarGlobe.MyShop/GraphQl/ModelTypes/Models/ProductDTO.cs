using System;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes.Models
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductTypeDTO ProductType { get; set; }
        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }
        public decimal SellingPrice { get; set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}