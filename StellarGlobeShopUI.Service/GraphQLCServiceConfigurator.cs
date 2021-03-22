using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StellarGlobeShopUI.Service.GraphQl.Schemas;

namespace StellarGlobeShopUI.Service
{
    public static class GraphQLCServiceConfigurator
    {
        public static void SetUpGraphQLDependencies(IServiceCollection services)
        {
            //Schemas
            services.AddScoped<ISchema>(x => new RootSchema(x));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Scoped)
            .AddNewtonsoftJson(o =>
            {
                o.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                o.MaxDepth = 40;
            });
        }
    }
}