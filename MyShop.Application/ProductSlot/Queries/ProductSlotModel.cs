using System;
using MyShop.Domain.ProductTypes;
using MyShop.Domain.Shops;

namespace MyShop.Application.Products.Queries
{
    public class ProductSlotModel
    {
        public long ProductType { get; set; }

        public int Quantity { get; set; }
        public Guid Id { get; set; }
    }
}