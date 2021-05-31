using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StellarGlobeShop.Gateway.Service.GraphQl;

namespace StellarGlobeShop.Gateway.Service
{
    public static class GraphQLCServiceConfigurator
    {
        public const string MyShop = "myshop";

        public static void SetUpGraphQLDependencies(IServiceCollection services)
        {
            services.AddHttpClient(MyShop, c => c.BaseAddress = new Uri("https://localhost:5050/graphql"));

            services
                .AddGraphQLServer()
                .AddDiagnosticEventListener(x =>
                    new DiagnosticObserver(x.GetApplicationService<ILogger<DiagnosticObserver>>()))
                .AddQueryType<QueryType>()
                .AddRemoteSchema(MyShop);
            //.AddTypeExtensionsFromFile("./Stitching.graphql");
        }
    }
}