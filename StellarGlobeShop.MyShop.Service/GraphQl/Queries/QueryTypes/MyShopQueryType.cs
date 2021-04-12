using HotChocolate.Types;
using StellarGlobeShop.MyShop.Service.GraphQl.GraphQLModels.ModelTypes;

namespace StellarGlobeShop.MyShop.Service.GraphQl.Queries.QueryTypes
{
    public class MyShopQueryType : ObjectType<MyShopQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<MyShopQuery> descriptor)
        {
            descriptor
                .Field(f => f.GetShop(default!, default!))
                .Type<ShopType>();
            descriptor
                .Field(f => f.GetShops(default!))
                .Type<ListType<ShopType>>();
            descriptor
                .Field(f => f.GetProductTypes(default!))
                .Type<ListType<ProductTypeType>>();
        }
    }
}