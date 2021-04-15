using System;
using MyShop.Domain.Common;
using MyShop.Domain.ProductTypes;
using MyShop.Domain.Shops;

namespace MyShop.Domain.Products
{
    public class Product : IEntity
    {
        private readonly (int, int) _allowedRangeForStockQuantity = (0, 2000000000);
        private readonly (int, int) _allowedRangeForSellingQuantity = (0, 2000000000);
        private readonly (decimal, decimal) _allowedRangeForSellingPrice = (0, 20000000000);

        private int _stockQuantity;
        private int _sellingQuantity;
        private decimal _sellingPrice;

        public Product(ProductType productType)
        {
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
            if (value < _allowedRangeForStockQuantity.Item1 && value > _allowedRangeForStockQuantity.Item2)
                throw new ArgumentOutOfRangeException(
                    $"Setting Stock Quantity with value {value}. Allowed range: [{_allowedRangeForStockQuantity.Item1} , {_allowedRangeForStockQuantity.Item2}]"
                );
            _stockQuantity = value;
        }

        protected void SetSellingPrice(decimal value)
        {
            if (value < _allowedRangeForSellingPrice.Item1 && value > _allowedRangeForSellingPrice.Item2)
                throw new ArgumentOutOfRangeException(
                    $"Setting Stock Quantity with value {value}. Allowed range: [{_allowedRangeForSellingPrice.Item1} , {_allowedRangeForSellingPrice.Item2}]"
                );
            _sellingPrice = value;
        }

        protected void SetSellingQuantity(int value)
        {
            if (value < _allowedRangeForSellingQuantity.Item1 && value > _allowedRangeForSellingQuantity.Item2)
                throw new ArgumentOutOfRangeException(
                    $"Setting Stock Quantity with value {value}. Allowed range: [{_allowedRangeForSellingQuantity.Item1} , {_allowedRangeForSellingQuantity.Item2}]"
                );
            _sellingQuantity = value;
        }

        protected bool Equals(Product other)
        {
            return Id.Equals(other.Id) && ProductType.Equals(other.ProductType);
        }
    }
}