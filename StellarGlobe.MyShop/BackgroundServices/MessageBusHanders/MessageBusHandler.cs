using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.AspNetCore.Subscriptions.Messages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using StellarGlobe.MyShop.Services.MessageBus.RabbitMQ;

namespace StellarGlobe.MyShop.BackgroundServices.MessageBusHanders
{
    public abstract class MessageBusRequestHandler : BackgroundService, IMessageBusRequestHandler
    {
        public static readonly string ExchangeName = "MyShop";
        protected readonly string QueueName = "MyShop";
        protected readonly IMessageBus MessageBus;

        public MessageBusRequestHandler(
            IMessageBus messageBus)
        {
            MessageBus = messageBus;
            MessageBus.DeclareQueue(QueueName);
            MessageBus.BindQueueToExchange(QueueName, ExchangeName, RoutingKey);
        }

        protected string RoutingKey => QueueName;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
        }
    }
}