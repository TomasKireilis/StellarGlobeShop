using System.Linq;
using AutoMapper;
using HotChocolate;
using HotChocolate.Types;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ProductDTOType : ObjectType<ProductDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductDTO> descriptor)
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
            public ShopDTO GetShop(ProductDTO product, [ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
            {
                return mapper.Map<ShopDTO>(myShopContext.Shops.FirstOrDefault(x => x.Id == product.ShopId));
            }

            public ProductTypeDTO GetProductType(ProductDTO product, [ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
            {
                return mapper.Map<ProductTypeDTO>(myShopContext.ProductTypes.FirstOrDefault(x => x.Id == product.ProductTypeId));
            }
        }
    }
}