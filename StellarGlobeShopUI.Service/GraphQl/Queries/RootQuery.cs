using System;
using GraphQL.Types;

namespace StellarGlobeShopUI.Service.GraphQl.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IServiceProvider serviceProvider)
        {
            Field<MyShopQuery>(
                "stonkQuery",
                "Queries for stonks",
                resolve: context => serviceProvider.GetService(typeof(MyShopQuery)));
        }
    }
}