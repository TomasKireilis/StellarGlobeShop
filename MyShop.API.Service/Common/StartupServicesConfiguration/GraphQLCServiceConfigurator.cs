using Microsoft.Extensions.DependencyInjection;
using MyShop.API.Service.Common.GraphQl.QueryTypes;
using MyShop.API.Service.Products.Mutations.Types;
using MyShop.API.Service.ProductSlot;
using MyShop.API.Service.Shops;

namespace MyShop.API.Service.Common.StartupServicesConfiguration
{
    public static class GraphQLCServiceConfigurator
    {
        public static void SetUpGraphQLDependencies(IServiceCollection services)
        {
            services

                .AddGraphQLServer()

                .AddQueryType<MyShopQueryType>()
                .AddType<ShopType>()
                .AddType<ProductType>()
                .AddMutationType<ProductPurchaseMutationType>();
        }
    }
}