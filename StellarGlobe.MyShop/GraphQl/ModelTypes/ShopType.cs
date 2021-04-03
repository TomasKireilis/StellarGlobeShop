using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ShopType : ObjectType<Shop>
    {
        [UseDbContext(typeof(MyShopContext))]
        public IQueryable<Product> GetProducts([ScopedService] MyShopContext myShopContext)
        {
            return myShopContext.Products/*.Where(x => x.ShopId == shopId)*/;
        }

        protected override void Configure(IObjectTypeDescriptor<Shop> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<UuidType>();
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
            descriptor
                .Field(f => f.Products)
                .ResolveWith<Resolvers>(p => p.GetProducts(default!, default!))
                .UseDbContext<MyShopContext>();
        }

        public class Resolvers
        {
            public IQueryable<Product> GetProducts(Shop shop, [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.Products.Where(x => x.ShopId == shop.Id);
            }
        }
    }
}