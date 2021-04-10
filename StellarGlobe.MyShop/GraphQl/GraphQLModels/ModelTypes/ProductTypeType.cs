using HotChocolate.Types;

namespace StellarGlobe.MyShop.GraphQl.GraphQLModels.ModelTypes
{
    public class ProductTypeType : ObjectType<Application.Models.ProductType>
    {
        protected override void Configure(IObjectTypeDescriptor<Application.Models.ProductType> descriptor)
        {
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
        }

        public class Resolvers
        {
        }
    }
}