﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StellarGlobe.MyShop.Application.BackgroundServices.DomainHandlers;
using StellarGlobe.MyShop.Application.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders;

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