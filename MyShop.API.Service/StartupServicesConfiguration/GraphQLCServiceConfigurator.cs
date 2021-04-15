using Microsoft.Extensions.DependencyInjection;
using MyShop.API.Service.GraphQl.Models.ModelTypes;
using MyShop.API.Service.GraphQl.Mutations.MutationTypes;
using MyShop.API.Service.GraphQl.Queries.QueryTypes;

namespace MyShop.API.Service.StartupServicesConfiguration
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