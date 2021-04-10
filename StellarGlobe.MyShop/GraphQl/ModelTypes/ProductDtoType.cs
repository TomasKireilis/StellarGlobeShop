using System.Linq;
using AutoMapper;
using HotChocolate;
using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.ModelTypes.Models;
using StellarGlobe.MyShop.Infrastructure.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ProductDtoType : ObjectType<ProductDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor
                .Field(f => f.Id).Ignore();
            descriptor
                .Field(f => f.StockQuantity).Ignore();
            descriptor
                .Field(f => f.ProductType)
                .ResolveWith<Resolvers>(r => r.GetProductType(default!, default!, default!))
                .UseDbContext<MyShopContext>();
            descriptor
                .Field(f => f.StockQuantity)
                .Type<IntType>();
            descriptor
                .Field(f => f.ShopId).Ignore();
            descriptor
                .Field(f => f.Shop)
                .ResolveWith<Resolvers>(r => r.GetShop(default!, default!, default!))
                .UseDbContext<MyShopContext>();
        }

        public class Resolvers
        {
            public ShopDto GetShop(ProductDto product, [ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
            {
                return mapper.Map<ShopDto>(myShopContext.Shops.FirstOrDefault(x => x.Id == product.ShopId));
            }

            public ProductTypeDto GetProductType(ProductDto product, [ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
            {
                return mapper.Map<ProductTypeDto>(myShopContext.ProductTypes.FirstOrDefault(x => x.Id == product.ProductTypeId));
            }
        }
    }
}