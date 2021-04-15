using System;
using MyShop.Domain.ProductTypes;
using MyShop.Domain.Shops;

namespace MyShop.Application.Products.Queries
{
    public class ProductModel
    {
        public string ProductTypeName { get; set; }

        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }

        public decimal SellingPrice { get; set; }
        public Guid Id { get; set; }
    }
}