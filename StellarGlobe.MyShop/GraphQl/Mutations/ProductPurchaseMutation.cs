using System;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using MediatR;
using Microsoft.Extensions.Logging;
using StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders;
using StellarGlobe.MyShop.Application.Commands;
using StellarGlobe.MyShop.GraphQl.GraphQLModels.InputModels;
using StellarGlobe.MyShop.GraphQl.GraphQLModels.InputModels.Types;

namespace StellarGlobe.MyShop.GraphQl.Mutations
{
    public class ProductPurchaseMutation
    {
        public async Task<ProductPurchase> PurchaseProduct(ProductPurchase productPurchase,
            [Service] IMediator mediator,
            [Service] ILogger<ProductPurchaseMutation> logger)
        {
            try
            {
                var purchaseCommand = new ProductPurchaseCommand() { ProductPurchase = productPurchase };

                return await mediator.Send(purchaseCommand);
                //messageBus.DeclareExchange("MyShop", "topic");
                //if (messageBus.PublishMessage(new { userId, shopId, productType }, "PurchaseProduct", "MyShop"))
                //{
                //    return true;
                //}
            }
            catch (Exception ex)
            {
                logger.LogError(LoggerEvents.GenerateEventId(LoggerEventType.UnknownPurchaseProductMutationException),
                    ex,
                    $"{nameof(ProductPurchaseMutation)} PurchaseProduct encountered exception with ShopId: {productPurchase.ShopId},ProductType: {productPurchase.ProductType},UserId: {productPurchase.UserId}");

                throw;
            }
        }
    }
}