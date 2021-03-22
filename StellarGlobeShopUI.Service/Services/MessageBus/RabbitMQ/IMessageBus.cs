using System;
using System.Collections.Generic;
using RabbitMQ.Client;
using StellarGlobeShopUI.Service.Models;

namespace StellarGlobeShopUI.Service.Services.MessageBus.RabbitMQ
{
    public interface IMessageBus
    {
        bool EnsureOpenConnection();

        IConnection OpenNewConnection();

        bool ConnectionActive();

        bool DeclareQueue(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false,
            IDictionary<string, object> arguments = null);

        bool PublishMessage(object message, string routingKey, string exchange,
            IBasicProperties basicProperties = null);

        bool SubscribeToQueueMessageEvent<T>(Action<T> handler, string queueName);

        bool DeclareExchange(string exchangeName, string type, bool durable = true,
            bool autoDelete = false, IDictionary<string, object> arguments = null);

        bool BindQueueToExchange(string queueName, string exchangeName, string routingKey,
            IDictionary<string, object> arguments = null);
    }
}