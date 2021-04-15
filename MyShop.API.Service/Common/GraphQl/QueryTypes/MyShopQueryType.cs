using HotChocolate.Types;
using MyShop.API.Service.ProductTypes;
using MyShop.API.Service.Shops;

namespace MyShop.API.Service.Common.GraphQl.QueryTypes
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