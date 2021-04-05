﻿using System;
using System.Collections.Generic;
using HotChocolate;
using System.Linq;
using HotChocolate.Data;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.Models;
using ProductType = StellarGlobe.MyShop.Models.ProductType;

namespace StellarGlobe.MyShop.GraphQl.Queries
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