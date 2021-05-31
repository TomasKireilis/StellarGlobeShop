using System;
using MyShop.Domain.Common;
using MyShop.Domain.Common.PositiveNumber;
using MyShop.Domain.ProductTypes;

namespace MyShop.Domain.Products
{
    public class Product : IEntity
    {
        private PositiveInteger _stockQuantity;
        private PositiveInteger _sellingQuantity;
        private PositiveDecimal _sellingPrice;

        public Product(Guid id, ProductType productType)
        {
            Id = id;
            ProductType = productType;
        }

        public ProductType ProductType { get; }

        public int StockQuantity
        {
            get => _stockQuantity;
            internal set => SetStockQuantity(value);
        }

        public int SellingQuantity
        {
            get => _sellingQuantity;
            internal set => SetSellingQuantity(value);
        }

        public decimal SellingPrice
        {
            get => _sellingPrice;
            internal set => SetSellingPrice(value);
        }

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

        protected void SetStockQuantity(int value)
        {
            _stockQuantity = value;
        }

        protected void SetSellingPrice(decimal value)
        {
            _sellingPrice = value;
        }

        protected void SetSellingQuantity(int value)
        {
            _sellingQuantity = value;
        }

        protected bool Equals(Product other)
        {
            return Id.Equals(other.Id) && ProductType.Equals(other.ProductType);
        }
    }
}