using System;
using Microsoft.Extensions.DependencyInjection;
using StellarGlobeShopUI.Service.GraphQl.Queries;

namespace StellarGlobeShopUI.Service.GraphQl
{
    public static class GraphQLCServiceConfigurator
    {
        public static void SetUpGraphQLDependencies(IServiceCollection services)
        {
            services.AddHttpClient("myShop", (sp, client) =>
            {
                client.BaseAddress = new Uri("https://localhost:5002");
            });

            services.AddStitchedSchema(builder => builder
                .AddSchemaFromHttp("myShop")
                .AddSchemaConfiguration(c =>
                {
                    c.RegisterExtendedScalarTypes();
                }));
            services.AddScoped<MyShopQuery>();
            services.AddGraphQLServer()
                .AddQueryType<RootQuery>();
        }
    }
}