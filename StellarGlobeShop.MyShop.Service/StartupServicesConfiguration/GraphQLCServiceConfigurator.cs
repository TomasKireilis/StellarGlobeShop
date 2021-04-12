using Microsoft.Extensions.DependencyInjection;
using StellarGlobeShop.MyShop.Service.GraphQl.GraphQLModels.ModelTypes;
using StellarGlobeShop.MyShop.Service.GraphQl.Mutations.MutationTypes;
using StellarGlobeShop.MyShop.Service.GraphQl.Queries.QueryTypes;

namespace StellarGlobeShop.MyShop.Service.StartupServicesConfiguration
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