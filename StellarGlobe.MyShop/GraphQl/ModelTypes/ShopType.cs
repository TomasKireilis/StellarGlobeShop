using System;
using System.Linq;
using AutoMapper;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using StellarGlobe.MyShop.Application.Models;
using StellarGlobe.MyShop.Infrastructure.Database;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ShopType : ObjectType<Shop>
    {
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
                .UseDbContext<MyShopContext>()
                .Type<ListType<ProductType>>();
            descriptor
                .Field("product")
                .Argument("productType", x => x.Type<StringType>())
                .UseDbContext<MyShopContext>()
                .ResolveWith<Resolvers>(p => p.GetProduct(default!, default!, default!))
                .Type<ProductType>();
        }

        public class Resolvers
        {
            public IQueryable<Product> GetProducts(Shop shop, [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.Products.Where(x => x.ShopId == shop.Id);
            }

            public Product GetProduct(Shop shop, [ScopedService] MyShopContext myShopContext, IResolverContext resolverContext)
            {
                var productType = resolverContext.ArgumentValue<string>("productType");
                return myShopContext.Products.FirstOrDefault(x => x.ProductType.Name == productType && shop.Id == x.ShopId);
            }
        }
    }
}