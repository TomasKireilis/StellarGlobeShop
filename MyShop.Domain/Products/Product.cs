using System;
using MyShop.Domain.Common;
using MyShop.Domain.ProductTypes;
using MyShop.Domain.Shops;

namespace MyShop.Domain.Products
{
    public class Product : IEntity
    {
        public Product(ProductType productType)
        {
            ProductType = productType;
        }

        public ProductType ProductType { get; }
        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }

        public decimal SellingPrice { get; set; }
        public Guid Id { get; }

        public override bool Equals(object? obj)
        {
            var otherProduct = obj as Product;
            if (otherProduct == null)
            {
                return false;
            }
            return Equals(otherProduct);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ProductType);
        }

        protected bool Equals(Product other)
        {
            return Id.Equals(other.Id) && ProductType.Equals(other.ProductType);
        }
    }
}