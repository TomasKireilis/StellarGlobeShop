using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.Queries;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class MyShopQueryType : ObjectType<MyShopQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<MyShopQuery> descriptor)
        {
            descriptor
                .Field(f => f.GetShop(default!, default!, default!))
                .Type<ShopDTOType>();
            descriptor
                .Field(f => f.GetShops(default!, default!))
                .Type<ListType<ShopDTOType>>();
            descriptor
                .Field(f => f.GetProductTypes(default!, default!))
                .Type<ListType<ProductTypeDTOType>>();
        }
    }
}