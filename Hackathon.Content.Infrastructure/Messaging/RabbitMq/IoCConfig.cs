using Hackathon.Content.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Configuration;
using RawRabbit.DependencyInjection.ServiceCollection;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using System;

namespace Hackathon.Content.Infrastructure.Messaging.RabbitMq
{
    public static class IoCConfig
    {
        public static IServiceCollection AddRabbitMqMessaging(this IServiceCollection container, IConfiguration configuration)
        {
			var rabbitMqSettings = configuration.GetSection("RabbitMq").Get<RawRabbitConfiguration>();
			if (rabbitMqSettings == null)
			{
				throw new Exception($"{nameof(RawRabbitConfiguration)} are not configured");
			}

			container.AddRawRabbit(new RawRabbitOptions
			{
				ClientConfiguration = rabbitMqSettings
			});


			container.AddSingleton<IMessageBroker, RabbitMqMessageBroker>();

            return container;
        }
    }
}