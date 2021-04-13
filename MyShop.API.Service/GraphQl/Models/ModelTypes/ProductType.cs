using HotChocolate;
using HotChocolate.Types;
using MyShop.Application.Application.Models;

namespace MyShop.API.Service.GraphQl.GraphQLModels.ModelTypes
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor
                  .Field(f => f.StockQuantity).Ignore();

            descriptor
                .Field(f => f.ProductType)
                .ResolveWith<Resolvers>(r => r.GetProductType(default!, default!))
                .UseDbContext<MyShopContext>()
                .Type<ProductTypeType>();

            descriptor
                .Field(f => f.SellingQuantity)
                .Type<IntType>();

            descriptor
                .Field(f => f.SellingPrice)
                .Type<DecimalType>();

            descriptor
                .Field(f => f.ProductTypeName)
                .Type<StringType>();

            descriptor
                .Field(f => f.ShopId).Ignore();

            descriptor
                .Field(f => f.Shop)
                .ResolveWith<Resolvers>(r => r.GetShop(default!, default!))
                .UseDbContext<MyShopContext>()
                .Type<ShopType>();
        }

        public class Resolvers
        {
            public Shop GetShop(Product product, [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.Shops.FirstOrDefault(x => x.Id == product.ShopId);
            }

            public Application.Application.Models.ProductType GetProductType(
                Product product,
                [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.ProductTypes.FirstOrDefault(x => x.Name == product.ProductTypeName);
            }
        }
    }
}