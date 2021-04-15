using HotChocolate.Types;

namespace MyShop.API.Service.GraphQl.Models.ModelTypes
{
    public class ProductTypeType : ObjectType<Application.Application.Models.ProductType>
    {
        protected override void Configure(IObjectTypeDescriptor<Application.Application.Models.ProductType> descriptor)
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