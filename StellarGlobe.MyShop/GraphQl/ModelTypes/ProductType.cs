using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor
                .Field(f => f.Id).Ignore();
            descriptor
                .Field(f => f.StockQuantity).Ignore();
            descriptor
                .Field(f => f.ProductType)
                .ResolveWith<Resolvers>(r => r.GetProductType(default!, default!))
                .UseDbContext<MyShopContext>();
            descriptor
                .Field(f => f.StockQuantity)
                .Type<IntType>();
            descriptor
                .Field(f => f.ShopId).Ignore();
            descriptor
                .Field(f => f.Shop)
                .ResolveWith<Resolvers>(r => r.GetShop(default!, default!))
                .UseDbContext<MyShopContext>();
        }

        public class Resolvers
        {
            public Shop GetShop(Product product, [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.Shops.FirstOrDefault(x => x.Id == product.ShopId);
            }

            public Models.ProductType GetProductType(Product product, [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.ProductTypes.FirstOrDefault(x => x.Id == product.ProductTypeId);
            }
        }
    }
}