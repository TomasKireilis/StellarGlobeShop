﻿using HotChocolate.Types;
using MyShop.API.Service.GraphQl.Models.ModelTypes;

namespace MyShop.API.Service.GraphQl.Queries.QueryTypes
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