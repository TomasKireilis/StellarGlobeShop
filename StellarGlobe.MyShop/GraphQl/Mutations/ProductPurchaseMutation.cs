using System;
using HotChocolate;
using StellarGlobe.MyShop.Infrastructure.Services.MessageBus.RabbitMQ;

namespace StellarGlobe.MyShop.GraphQl.Mutations
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