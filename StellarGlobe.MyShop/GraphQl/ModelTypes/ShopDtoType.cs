using System;
using System.Linq;
using AutoMapper;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.ModelTypes.Models;
using StellarGlobe.MyShop.Infrastructure.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ShopDtoType : ObjectType<ShopDto>
    {
        [UseDbContext(typeof(MyShopContext))]
        public IQueryable<Product> GetProducts([ScopedService] MyShopContext myShopContext)
        {
            return myShopContext.Products/*.Where(x => x.ShopId == shopId)*/;
        }

        protected override void Configure(IObjectTypeDescriptor<ShopDto> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<UuidType>();
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
            descriptor
                .Field(f => f.Products)
                .ResolveWith<Resolvers>(p => p.GetProducts(default!, default!, default!))
                .UseDbContext<MyShopContext>();
            descriptor
                .Field("product")
                .Argument("productType", x => x.Type<StringType>())
                .UseDbContext<MyShopContext>()
                .ResolveWith<Resolvers>(p => p.GetProduct(default!, default!, default!, default!))

                .Type<ProductDtoType>();
        }

        public class Resolvers
        {
            public IQueryable<ProductDto> GetProducts(ShopDto shop, [ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
            {
                return mapper.Map<IQueryable<ProductDto>>(myShopContext.Products.Where(x => x.ShopId == shop.Id));
            }

            public ProductDto GetProduct(ShopDto shop, [ScopedService] MyShopContext myShopContext, IResolverContext resolverContext, [Service] IMapper mapper)
            {
                var productType = resolverContext.ArgumentValue<string>("productType");
                return mapper.Map<ProductDto>(myShopContext.Products.FirstOrDefault(x => x.ProductType.Name == productType && shop.Id == x.ShopId));
            }
        }
    }
}