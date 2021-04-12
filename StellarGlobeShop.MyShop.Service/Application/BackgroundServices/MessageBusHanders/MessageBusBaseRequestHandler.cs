using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StellarGlobeShop.MyShop.Service.Infrastructure.Services.MessageBus.RabbitMQ;

namespace StellarGlobeShop.MyShop.Service.Application.BackgroundServices.MessageBusHanders
{
    public abstract class MessageBusBaseRequestHandler<T> : BackgroundService, IMessageBusRequestHandler
    {
        protected readonly string ExchangeName = "MyShop";
        protected readonly IMessageBus MessageBus;
        private string _queueName = "MyShop";

        protected MessageBusBaseRequestHandler(
            IMessageBus messageBus)
        {
            MessageBus = messageBus;
        }

        public string QueueName
        {
            get => _queueName;
            set
            {
                if (value != null) _queueName += $".{value}";
            }
        }

        protected string RoutingKey => QueueName;

        protected abstract void HandleMessage(T message);

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MessageBus.DeclareQueue(QueueName);
            MessageBus.DeclareExchange(ExchangeName, "topic");
            MessageBus.BindQueueToExchange(QueueName, ExchangeName, RoutingKey);

            MessageBus.SubscribeToQueueMessageEvent<T>(HandleMessage, QueueName);
            return Task.CompletedTask;
        }
    }
}