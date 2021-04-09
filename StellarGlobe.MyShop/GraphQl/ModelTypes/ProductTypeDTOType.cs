using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.ModelTypes.Models;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ProductTypeDTOType : ObjectType<ProductTypeDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductTypeDTO> descriptor)
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