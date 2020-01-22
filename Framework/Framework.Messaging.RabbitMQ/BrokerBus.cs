using Framework.Core.Event;
using Framework.Core.Helpers;
using Framework.Core.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace Framework.Messaging.RabbitMQ
{
    public class BrokerBus : IBrokerBus
    {
        public void Publish<TEvent>(TEvent message) where TEvent : IEvent
        {
            ConnectionFactory factory = CreateConnectionFactory();
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: GenerateQueueName(typeof(TEvent)),
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = ByteArrayHelper.ObjectToByteArray(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: GenerateQueueName(typeof(TEvent)),
                                         basicProperties: null,
                                         body: body);
                }
            }
        }
        
        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            ConnectionFactory factory = CreateConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: GenerateQueueName(typeof(TEvent)),
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = ByteArrayHelper.ByteArrayToObject<TEvent>(body);
                eventHandler.Handle(message);
            };
            channel.BasicConsume(queue: GenerateQueueName(typeof(TEvent)),
                                 autoAck: true,
                                 consumer: consumer);
        }

        private static ConnectionFactory CreateConnectionFactory()
        {
            return new ConnectionFactory() { HostName = "192.168.10.23", UserName = "BrokerUser", Password = "123456" };
        }

        private string GenerateQueueName(Type messageType)
        {
            return $"{messageType.Name}";
        }

        private string GenerateExchangeName(Type messageType)
        {
            return $"{messageType.Name}";
        }
    }
}