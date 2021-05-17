using System;
using MyShop.Domain.Common;
using MyShop.Domain.Products;

namespace MyShop.Domain.ProductTypes
{
    public class ProductType : ValueObject<ProductType>
    {
        public ProductType(string name)
        {
            Name = name;
        }

        public string Name { get; }

        protected override bool EqualsCore(ProductType obj)
        {
            if (Name != obj.Name)
            {
                return false;
            }

            return true;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Name);
        }
    }
}