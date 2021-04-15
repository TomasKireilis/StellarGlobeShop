using System;
using MyShop.Application.Shops.Queries;

namespace MyShop.Application.Products.Queries
{
    public interface IGetShopQuery
    {
        ShopModel Execute(Guid shopId);
    }
}