using System;
using System.Collections.Generic;
using System.Text;
using MyShop.Application.Shops.Queries;
using MyShop.Domain.Shops;

namespace MyShop.Application.Products.Queries
{
    public class GetShopQuery : IGetShopQuery
    {
        public ShopModel Execute(Guid shopId)
        {
            return new ShopModel();
        }
    };
}
}