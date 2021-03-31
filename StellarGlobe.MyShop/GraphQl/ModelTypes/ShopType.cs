using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate.Types;
using StellarGlobe.MyShop.Database;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class ShopType : ObjectType<Shop>
    {
        protected override void Configure(IObjectTypeDescriptor<Shop> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<UuidType>();
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();
            descriptor
                .Field(f => f.Products)
                .Type<ListType<ProductType>>();
        }
    }
}