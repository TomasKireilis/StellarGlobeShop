using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using StellarGlobeShop.MyShop.Service.Application.Models;
using StellarGlobeShop.MyShop.Service.Infrastructure.Database;

namespace StellarGlobeShop.MyShop.Service.GraphQl.Queries
{
    public class MyShopQuery
    {
        [UseDbContext(typeof(MyShopContext))]
        public Shop GetShop(Guid id, [ScopedService] MyShopContext myShopContext)
        {
            return myShopContext.Shops.FirstOrDefault(x => x.Id == id);
        }

        [UseDbContext(typeof(MyShopContext))]
        public List<Shop> GetShops([ScopedService] MyShopContext myShopContext)
        {
            return myShopContext.Shops.ToList();
        }

        [UseDbContext(typeof(MyShopContext))]
        public List<ProductType> GetProductTypes([ScopedService] MyShopContext myShopContext)
        {
            return myShopContext.ProductTypes.ToList();
        }
    }
}