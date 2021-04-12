using Microsoft.Extensions.DependencyInjection;
using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.DomainHandlers;
using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobeShop.MyShop.Service.StartupServicesConfiguration
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