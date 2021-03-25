using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQLibrary.Interfaces;

namespace RabbitMQLibrary
{
    public class RabbitMqClient : IRabbitMQClient
    {
        public IConnection Connection;
        public IModel Channel;
        private readonly ConnectionFactory _connectionFactory;

        private EventingBasicConsumer _consumer;
        private ILogger<RabbitMqClient> _logger;

        public RabbitMqClient(ConnectionFactory connectionFactory, RabbitMqConnectionData connectionData, ILogger<RabbitMqClient> logger, bool openConnection = true)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
            _connectionFactory.UserName = connectionData.UserName;
            _connectionFactory.Password = connectionData.Password;
            _connectionFactory.VirtualHost = connectionData.VirtualHost;
            _connectionFactory.HostName = connectionData.HostName;
            _connectionFactory.Port = connectionData.Port;
            if (openConnection) OpenNewConnection();
        }

        public bool EnsureOpenConnection()
        {
            if (ConnectionActive()) return true;
            OpenNewConnection();
            if (ConnectionActive()) return true;
            return false;
        }

        public IConnection OpenNewConnection()
        {
            Connection?.Close();
            Connection = _connectionFactory.CreateConnection();
            Channel = Connection.CreateModel();
            Channel.ConfirmSelect();

            return Connection;
        }

        public bool ConnectionActive()
        {
            return Connection?.IsOpen ?? false;
        }

        public bool DeclareQueue(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            try
            {
                Channel.QueueDeclare(queueName, durable, exclusive, autoDelete, arguments);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + e.StackTrace);
                return false;
            }

            return true;
        }

        public bool BindQueueToExchange(string queueName, string exchangeName, string routingKey, IDictionary<string, object> arguments = null)
        {
            try
            {
                Channel.QueueBind(queueName, exchangeName, routingKey, arguments);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + e.StackTrace);
                return false;
            }

            return true;
        }

        public bool DeclareExchange(string exchangeName, string type, bool durable = true, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            try
            {
                Channel.ExchangeDeclare(exchangeName, type, durable, autoDelete, arguments);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + e.StackTrace);
                return false;
            }

            return true;
        }

        public bool PublishMessage(object message, string routingKey, string exchange = "", IBasicProperties basicProperties = null)
        {
            try
            {
                Channel.BasicPublish(exchange, routingKey, basicProperties, message.Serialize());
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + e.StackTrace);
                return false;
            }
            return HandleConfirms();
        }

        public bool SubscribeToQueueMessageEvent<T>(Action<T> handler, string queueName)
        {
            try
            {
                _consumer.Received += (ch, eventArgs) => ProcessMessage(eventArgs, handler);
                Channel.BasicConsume(_consumer, queueName);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + e.StackTrace);
                return false;
            }
            return true;
        }

        public bool ProcessMessage<T>(BasicDeliverEventArgs eventArgs, Action<T> handler)
        {
            var body = eventArgs.Body.ToArray();
            try
            {
                var message = JsonConvert.DeserializeObject<T>(body.DeSerializeText());
                handler.Invoke(message);
                Channel.BasicAck(eventArgs.DeliveryTag, false);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + e.StackTrace);
                return false;
            }
            return true;
        }

        public bool HandleConfirms()
        {
            try
            {
                Channel.WaitForConfirmsOrDie(new TimeSpan(0, 0, 5));
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + e.StackTrace);
                return false;
            }
            return true;
        }
    }
}