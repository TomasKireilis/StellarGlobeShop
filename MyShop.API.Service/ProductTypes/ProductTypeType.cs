using HotChocolate.Types;
using MyShop.Persistance.ProductTypes;

namespace MyShop.API.Service.ProductTypes
{
    public class ProductTypeType : ObjectType<ProductType>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductType> descriptor)
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