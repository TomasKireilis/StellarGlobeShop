using System;
using System.Collections.Generic;
using HotChocolate;
using System.Linq;
using HotChocolate.Data;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.Models;
using StellarGlobe.MyShop.Services.MessageBus.RabbitMQ;
using ProductType = StellarGlobe.MyShop.Models.ProductType;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class ProductPurchaseMutation
    {
        public bool PurchaseProduct(Guid userId, Guid shopId, string productType, [Service] IMessageBus messageBus)
        {
            messageBus.DeclareExchange("MyShop", "topic");
            if (messageBus.PublishMessage(new { userId, shopId, productType }, "PurchaseProduct", "MyShop"))
            {
                return true;
            }

            return false;
        }
    }
}