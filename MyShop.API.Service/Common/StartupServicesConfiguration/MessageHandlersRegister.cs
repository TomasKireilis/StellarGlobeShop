using Microsoft.Extensions.DependencyInjection;
using MyShop.Application.Application.BackgroundServices.DomainHandlers;
using MyShop.Application.Application.BackgroundServices.DomainHandlers.Interfaces;
using MyShop.Application.Application.BackgroundServices.MessageBusHanders;

namespace MyShop.API.Service.Common.StartupServicesConfiguration
{
    public static class MessageHandlersRegister
    {
        public static void RegisterMessageHandlers(IServiceCollection service)
        {
            //Domain Handlers
            service.AddTransient<ProductEventsHandler>();
            service.AddTransient<IProductPurchaseHandler>(x => x.GetService<ProductEventsHandler>());

            //Message Bus Handlers
            //service.AddHostedService<MessageBusProductPurchaseHandler>();
        }
    }
}