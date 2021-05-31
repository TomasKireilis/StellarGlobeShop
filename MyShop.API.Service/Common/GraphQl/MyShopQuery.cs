using System;
using System.Collections.Generic;
using AutoMapper;
using HotChocolate;
using HotChocolate.Data;
using MyShop.API.Service.Shops;
using MyShop.Application.Products.Queries;

namespace MyShop.API.Service.Common.GraphQl
{
    public class MyShopQuery
    {
        public ShopType GetShop(Guid id, [ScopedService] IGetShopQuery query, [ScopedService] IMapper mapper)
        {
            var shopModel = query.Execute(id);

            return mapper.Map<ShopType>(shopModel);
        }

        public List<ShopType> GetShops([ScopedService] IGetShopsQuery query, [ScopedService] IMapper mapper)
        {
            var shopModel = query.Execute();
            return mapper.Map<List<ShopType>>(shopModel);
        }

        //public List<ProductType> GetProductTypes([ScopedService] MyShopContext myShopContext)
        //{
        //    return myShopContext.ProductTypes.ToList();
        //}
    }
}