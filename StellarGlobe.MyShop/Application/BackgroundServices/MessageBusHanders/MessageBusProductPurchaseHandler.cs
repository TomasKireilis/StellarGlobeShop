using Microsoft.Extensions.Logging;
using StellarGlobe.MyShop.Application.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobe.MyShop.Infrastructure.Services.MessageBus.RabbitMQ;

namespace StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders
{
    public class MessageBusProductPurchaseHandler : MessageBusBaseRequestHandler<ProductPurchase>
    {
        private readonly IProductPurchaseHandler _productPurchaseHandler;
        private readonly ILogger<MessageBusProductPurchaseHandler> _logger;

        public MessageBusProductPurchaseHandler(
            IMessageBus messageBus,
            IProductPurchaseHandler productPurchaseHandler,
            ILogger<MessageBusProductPurchaseHandler> logger) : base(messageBus)
        {
            _productPurchaseHandler = productPurchaseHandler;
            _logger = logger;
            QueueName = "ProductPurchase";
        }

        protected override void HandleMessage(ProductPurchase message)
        {
            if (_productPurchaseHandler == null)
            {
                _logger.LogWarning(
                    LoggerEvents.GenerateEventId(LoggerEventType.MissingMessageBusDomainHandler),
                    $"{nameof(MessageBusProductPurchaseHandler)}: IProductPurchaseHandler is not registered");
                return;
            }
            _productPurchaseHandler.HandleProductPurchase(message);
        }
    }
}