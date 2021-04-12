using HotChocolate.Types;

namespace StellarGlobeShop.Gateway.Service.GraphQl
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