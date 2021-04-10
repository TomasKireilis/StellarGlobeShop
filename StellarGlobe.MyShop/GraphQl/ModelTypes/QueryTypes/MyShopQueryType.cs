﻿using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.Queries;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes.QueryTypes
{
    public class MyShopQueryType : ObjectType<MyShopQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<MyShopQuery> descriptor)
        {
            descriptor
                .Field(f => f.GetShop(default!, default!, default!))
                .Type<ShopDtoType>();
            descriptor
                .Field(f => f.GetShops(default!, default!))
                .Type<ListType<ShopDtoType>>();
            descriptor
                .Field(f => f.GetProductTypes(default!, default!))
                .Type<ListType<ProductTypeDtoType>>();
        }
    }
}