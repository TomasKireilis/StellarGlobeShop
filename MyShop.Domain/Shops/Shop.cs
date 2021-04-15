using System;
using System.Collections.Generic;
using System.Text;
using MyShop.Domain.Common;
using MyShop.Domain.Products;

namespace MyShop.Domain.Shops
{
    public class Shop : IEntity
    {
        public Shop(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public Guid Id { get; }

        public string Name { get; }

        public List<Product> Products { get; internal set; }

        public int AddProducts(List<Product> products)
        {
        }

        public int AddProduct(Product products)
        {
        }

        public override bool Equals(object? obj)
        {
            var otherShop = obj as Shop;
            if (otherShop == null)
            {
                return false;
            }
            return Equals(otherShop);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        protected bool Equals(Shop other)
        {
            return Id.Equals(other.Id) && Name == other.Name;
        }
    }
}