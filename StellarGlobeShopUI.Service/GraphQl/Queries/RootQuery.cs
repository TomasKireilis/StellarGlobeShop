using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using GraphQL.Types;
using HotChocolate;
using StellarGlobeShopUI.Service.GraphQl.ModelTypes;

namespace StellarGlobeShopUI.Service.GraphQl.Queries
{
    public class RootQuery
    {
        public MyShopQuery MyShopProduct([Service] MyShopQuery myShopQuery)
        {
            return myShopQuery;
        }
    }
}