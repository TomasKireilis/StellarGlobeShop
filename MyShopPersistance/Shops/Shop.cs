using System.Collections.Generic;
using MyShopPersistance.Common;

namespace MyShopPersistance.Shops
{
    public class Shop : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}