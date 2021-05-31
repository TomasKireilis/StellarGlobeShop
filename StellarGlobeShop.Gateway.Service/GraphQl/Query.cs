using HotChocolate.Types;

namespace StellarGlobeShop.Gateway.Service.GraphQl
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(f => f.Ping());
        }
    }

    public class Query
    {
        public string Ping() => "true";
    }
}