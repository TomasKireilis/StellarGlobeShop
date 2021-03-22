using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using StellarGlobeShopUI.Service.GraphQl.Queries;

namespace StellarGlobeShopUI.Service.GraphQl.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
        }
    }
}