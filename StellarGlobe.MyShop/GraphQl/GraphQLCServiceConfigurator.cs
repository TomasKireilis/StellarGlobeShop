using Microsoft.Extensions.DependencyInjection;
using StellarGlobe.MyShop.GraphQl.ModelTypes;
using StellarGlobe.MyShop.GraphQl.Queries;

namespace StellarGlobe.MyShop.GraphQl
{
    public static class GraphQLCServiceConfigurator
    {
        public static void SetUpGraphQLDependencies(IServiceCollection services)
        {
            services

                .AddGraphQLServer()
                .AddQueryType<MyShopQueryType>()
                .AddType<ShopType>()
                .AddType<ProductType>();
        }
    }
}