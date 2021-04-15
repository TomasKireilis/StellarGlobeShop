using System;
using MyShop.Domain.Common;
using MyShop.Domain.Products;

namespace MyShop.Domain.ProductTypes
{
    public class ProductType : IEntity
    {
        public ProductType(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public Guid Id { get; }

        public override bool Equals(object? obj)
        {
            var otherProductType = obj as ProductType;
            if (otherProductType == null)
            {
                return false;
            }
            return Equals(otherProductType);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        protected bool Equals(ProductType other)
        {
            return Id.Equals(other.Id) && Name == other.Name;
        }
    }
}