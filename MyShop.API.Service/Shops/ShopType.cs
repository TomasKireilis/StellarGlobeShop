using System.Linq;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using MyShop.API.Service.Products;
using MyShop.Application.Products.Queries;
using MyShop.Persistance.Database;

namespace MyShop.API.Service.Shops
{
    public class ShopType : ObjectType<ProductModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductModel> descriptor)
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
            public IQueryable<Product> GetProducts(ProductModel shop, [ScopedService] MyShopContext myShopContext)
            {
                return myShopContext.Products.Where(x => x.ShopId == shop.Id);
            }

            public Product GetProduct(ProductModel shop, [ScopedService] MyShopContext myShopContext, IResolverContext resolverContext)
            {
                var productType = resolverContext.ArgumentValue<string>("productType");
                return myShopContext.Products.FirstOrDefault(x => x.ProductType.Name == productType && shop.Id == x.ShopId);
            }
        }
    }
}