using AllInOneAPI.Interfaces;
using AllInOneAPI.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace AllInOneAPI.Infrastructure
{
    public class RMQConnector : IRMQConnector
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly ILogger _logger;

        public RMQConnector(ILogger<RMQConnector> logger)
        {
            _logger = logger;
            InitRabbitMQ();
            

        }

        public void InitRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.BasicQos(0, 1, false);
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e)
        {
            _logger.LogInformation($"consumer registered {e.ConsumerTag}");
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
            _logger.LogInformation($"consumer registered {e.ConsumerTag}");
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
            _logger.LogInformation($"consumer registered {e.ConsumerTag}");
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
            _logger.LogInformation($"consumer shutdown {e.ReplyText}");
        }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            _logger.LogInformation($"connection shut down {e.ReplyText}");
        }

        public bool PublishMessage(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>> imageDetailsForPikleGeneration)
        {
            try
            {
                var rmqMessage = new RMQMessage
                {
                    ImageDetailsForPikleGeneration = imageDetailsForPikleGeneration
                };

                //var exchange = _RMQBus.ExchangeDeclare(appSettings.RMQPublisherTopic, ExchangeType.Topic);
                //var rmqPayload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(rmqMessage));
                //_RMQBus.Publish(exchange, appSettings.RMQPublisherTopic, true, new MessageProperties(), rmqPayload);




            }
            catch  (Exception exception)
            {
                return false;
            }
          

            
            return true;
        }
    }
}
