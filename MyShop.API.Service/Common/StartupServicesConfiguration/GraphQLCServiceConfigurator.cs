using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using MyShop.API.Service.Product;
using MyShop.API.Service.ProductSlot;

namespace MyShop.API.Service.Common.StartupServicesConfiguration
{
    public static class GraphQLCServiceConfigurator
    {
        public static void SetUpGraphQLDependencies(IServiceCollection services)
        {
            services

                .AddGraphQLServer()
                .AddQueryType<MyShopQuery>();
            //.AddType<ProductSlotType>()
            //.AddType<ProductType>();
        }
    }

    public class MyShopQuery : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor
                .Field("ProductSlot").Resolve(x => new ProductSlotType());
            descriptor
                .Field("Product").Resolve(x => new ProductType());
        }
    }
}