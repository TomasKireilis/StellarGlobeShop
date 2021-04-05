using HotChocolate.Types;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ProductTypeType : ObjectType<Models.ProductType>
    {
        protected override void Configure(IObjectTypeDescriptor<Models.ProductType> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<UuidType>();
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
        }

        public class Resolvers
        {
        }
    }
}