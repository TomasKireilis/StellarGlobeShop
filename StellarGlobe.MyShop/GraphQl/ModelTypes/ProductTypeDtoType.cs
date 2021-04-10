using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.ModelTypes.Models;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ProductTypeDtoType : ObjectType<ProductTypeDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductTypeDto> descriptor)
        {
            descriptor
                .Field(f => f.Id).Ignore();
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
        }

        public class Resolvers
        {
        }
    }
}