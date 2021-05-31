using System;

namespace MyShop.Persistance.ProductSlots
{
    public class ProductSlot
    {
        public long ProductType { get; set; }

        public int Quantity { get; set; }
        public Guid Id { get; set; }
    }
}