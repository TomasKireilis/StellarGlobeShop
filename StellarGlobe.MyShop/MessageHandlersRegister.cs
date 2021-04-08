using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StellarGlobe.MyShop.BackgroundServices.DomainHandlers;
using StellarGlobe.MyShop.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobe.MyShop.BackgroundServices.MessageBusHanders;
using StellarGlobe.MyShop.Services.MessageBus.RabbitMQ;

namespace StellarGlobe.MyShop
{
    public static class MessageHandlersRegister
    {
        public static void RegisterMessageHandlers(IServiceCollection service)
        {
            //Domain Handlers
            service.AddTransient<ProductEventsHandler>();
            service.AddTransient<IProductPurchaseHandler>(x => x.GetService<ProductEventsHandler>());

            //Message Bus Handlers
            service.AddHostedService<MessageBusProductPurchaseHandler>();
        }
    }
}