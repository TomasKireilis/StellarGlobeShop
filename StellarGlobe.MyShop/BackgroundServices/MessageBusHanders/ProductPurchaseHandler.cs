using System.Threading;
using System.Threading.Tasks;
using StellarGlobe.MyShop.Services.MessageBus.RabbitMQ;

namespace StellarGlobe.MyShop.BackgroundServices.MessageBusHanders
{
    public abstract class ProductPurchaseHandler : MessageBusRequestHandler
    {
        public static readonly string ExchangeName = "MyShop";
        protected readonly string QueueName = "MyShop";

        public ProductPurchaseHandler(
            IMessageBus messageBus) : base(messageBus)
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MessageBus.SubscribeToQueueMessageEvent<ProductPurchase>(MessageHandler, QueueName);
        }

        protected override void MessageHandler(ProductPurchase value)
        {
        }
    }
}