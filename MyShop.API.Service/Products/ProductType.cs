using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using MyShop.API.Service.ProductTypes;
using MyShop.API.Service.Shops;
using MyShop.Application.Products.Queries;
using MyShop.Application.ProductTypes.Queries;
using MyShop.Application.Shops.Queries;
using MyShop.Persistance.Database;

namespace MyShop.API.Service.Products
{
    public class ProductType : ObjectType<ProductModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductModel> descriptor)
        {
            descriptor
                  .Field(f => f.StockQuantity).Ignore();

            descriptor
                .Field(f => f.ProductTypeModel)
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
                .Field(f => f.Shop)
                .ResolveWith<Resolvers>(r => r.GetShop(default!, default!))
                .UseDbContext<MyShopContext>()
                .Type<ShopType>();
        }

        public class Resolvers
        {
            public ShopModel GetShop(ProductModel product, [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.Shops.FirstOrDefault(x => x.Id == product.ShopId);
            }

            public ProductTypeModel GetProductType(
                ProductModel product,
                [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.ProductTypes.FirstOrDefault(x => x.Name == product.ProductTypeName);
            }
        }
    }
}