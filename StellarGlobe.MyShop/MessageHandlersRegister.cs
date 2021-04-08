using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StellarGlobe.MyShop.BackgroundServices.MessageBusHanders;

namespace StellarGlobe.MyShop
{
    public static class MessageHandlersRegister
    {
        public static void RegisterMessageHandlers(IServiceCollection service)
        {
            service.AddHostedService<MessageBusRequestHandler>();
        }
    }
}