using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace StellarGlobeShopUI.Service.GraphQl
{
    public class Query
    {
        public string GetDataString() => "labas";
    }

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(f => f.GetDataString())
                .Type<StringType>();
        }
    }
}