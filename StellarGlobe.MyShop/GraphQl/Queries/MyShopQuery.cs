using System;
using HotChocolate;
using System.Linq;
using HotChocolate.Data;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class MyShopQuery
    {
        [UseDbContext(typeof(MyShopContext))]
        public Shop GetShop(Guid id, [ScopedService] MyShopContext myShopContext)
        {
            return myShopContext.Shops.FirstOrDefault(x => x.Id == id);
        }
    }
}