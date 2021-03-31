﻿using HotChocolate;
using StellarGlobe.MyShop.GraphQl.ModelTypes;
using System.Collections.Generic;
using System.Linq;
using HotChocolate.Data;
using StellarGlobe.MyShop.Database;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class MyShopQuery
    {
        [UseDbContext(typeof(MyShopContext))]
        public IQueryable<Product> GetProducts([Service] MyShopContext myShopContext)
        {
            return myShopContext.Products;
        }
    }
}