using System.Collections.Generic;

namespace MyShop.Persistance.Shops
{
    public class Shop : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}