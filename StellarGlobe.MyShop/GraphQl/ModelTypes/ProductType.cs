using HotChocolate.Types;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<UuidType>();
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
            descriptor
                .Field(f => f.Quantity)
                .Type<IntType>();
        }
    }
}