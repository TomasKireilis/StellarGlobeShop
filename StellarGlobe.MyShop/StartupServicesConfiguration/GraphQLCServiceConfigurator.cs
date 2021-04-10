using Microsoft.Extensions.DependencyInjection;
using StellarGlobe.MyShop.GraphQl.GraphQLModels.ModelTypes;
using StellarGlobe.MyShop.GraphQl.Mutations.MutationTypes;
using StellarGlobe.MyShop.GraphQl.Queries.QueryTypes;

namespace StellarGlobe.MyShop.StartupServicesConfiguration
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