using Hackathon.Content.Application.Services;
using RawRabbit;
using System.Threading.Tasks;

namespace Hackathon.Content.Infrastructure.Messaging.RabbitMq
{
    public class RabbitMqMessageBroker : IMessageBroker
    {
        private readonly IBusClient _rabbitMqClient;

        public RabbitMqMessageBroker(IBusClient rabbitMqClient)
        {
            _rabbitMqClient = rabbitMqClient;
        }

        public async Task Publish(object @event)
        {                      
            await _rabbitMqClient.PublishAsync(@event, context =>
            {
                context.UsePublishConfiguration(x =>
                {
                    x.WithRoutingKey(@event.GetType().Name);
                });
            });
        }
    }
}
