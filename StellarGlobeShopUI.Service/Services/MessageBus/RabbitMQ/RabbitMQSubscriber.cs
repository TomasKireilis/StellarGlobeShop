using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;

namespace StellarGlobeShopUI.Service.Services.MessageBus.RabbitMQ
{
    public class RabbitMQSubscriber : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return null;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}