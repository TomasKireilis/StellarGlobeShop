using System;
using System.Collections.Generic;
using System.Text;
using MyShop.Domain.Common;

namespace MyShop.Domain.Shops
{
    public class Shop : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}