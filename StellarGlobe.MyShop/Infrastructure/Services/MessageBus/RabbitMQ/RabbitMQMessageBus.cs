using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQLibrary.Interfaces;

namespace StellarGlobe.MyShop.Infrastructure.Services.MessageBus.RabbitMQ
{
    internal class RabbitMQMessageBus : IMessageBus
    {
        public IRabbitMQClient RabbitMQClient;
        private ILogger<RabbitMQMessageBus> _logger;

        public RabbitMQMessageBus(IRabbitMQClient rabbitMQClient, ILogger<RabbitMQMessageBus> logger)
        {
            RabbitMQClient = rabbitMQClient;
            _logger = logger;
        }

        public bool EnsureOpenConnection()
        {
            return RabbitMQClient.EnsureOpenConnection();
        }

        public IConnection OpenNewConnection()
        {
            return RabbitMQClient.OpenNewConnection();
        }

        public bool ConnectionActive()
        {
            return RabbitMQClient.ConnectionActive();
        }

        public bool DeclareQueue(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false,
            IDictionary<string, object> arguments = null)
        {
            return RabbitMQClient.DeclareQueue(queueName, durable, exclusive, autoDelete, arguments);
        }

        public bool PublishMessage(object message, string routingKey, string exchange, IBasicProperties basicProperties = null)
        {
            return RabbitMQClient.PublishMessage(message, routingKey, exchange, basicProperties);
        }

        public bool SubscribeToQueueMessageEvent<T>(Action<T> handler, string queueName)
        {
            return RabbitMQClient.SubscribeToQueueMessageEvent(handler, queueName);
        }

        public bool DeclareExchange(string exchangeName, string type, bool durable = true, bool autoDelete = false,
            IDictionary<string, object> arguments = null)
        {
            return RabbitMQClient.DeclareExchange(exchangeName, type, durable, autoDelete, arguments);
        }

        public bool BindQueueToExchange(string queueName, string exchangeName, string routingKey, IDictionary<string, object> arguments = null)
        {
            return RabbitMQClient.BindQueueToExchange(queueName, exchangeName, routingKey, arguments);
        }
    }
}