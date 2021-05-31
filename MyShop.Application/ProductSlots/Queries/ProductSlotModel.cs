using System;

namespace MyShop.Application.ProductSlots.Queries
{
    public class ProductSlotModel
    {
        public long ProductType { get; set; }

        public int Quantity { get; set; }
        public Guid Id { get; set; }
    }
}