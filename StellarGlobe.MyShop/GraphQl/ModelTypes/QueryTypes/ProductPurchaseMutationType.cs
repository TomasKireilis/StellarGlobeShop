using System;
using System.Collections.Generic;
using HotChocolate;
using System.Linq;
using HotChocolate.Data;
using HotChocolate.Types;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.GraphQl.ModelTypes;
using StellarGlobe.MyShop.Models;
using StellarGlobe.MyShop.Services.MessageBus.RabbitMQ;
using ProductType = StellarGlobe.MyShop.Models.ProductType;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class ProductPurchaseMutationType : ObjectType<ProductPurchaseMutation>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductPurchaseMutation> descriptor)
        {
            descriptor

                .Field(f => f.PurchaseProduct(default, default, default, default))
                .Type<BooleanType>();
        }
    }
}