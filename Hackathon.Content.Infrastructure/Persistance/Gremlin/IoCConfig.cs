using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Remote;
using Gremlin.Net.Process.Traversal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hackathon.Content.Infrastructure.Persistance.Gremlin
{
    public static class IoCConfig
    {
        public static IServiceCollection AddGremlinPersistence(this IServiceCollection container, IConfiguration configuration)
        {
            var gremlinSettings = configuration.GetSection("Gremlin").Get<GremlinSettings>();
            if (gremlinSettings == null)
            {
                throw new Exception($"{nameof(GremlinSettings)} are not configured");
            }

            container.AddSingleton(
               (serviceProvider) =>
               {
                   var gremlinServer = new GremlinServer(
                       hostname: gremlinSettings.Hostname,
                       port: gremlinSettings.Port,
                       enableSsl: false,
                       username: null,
                       password: null
                   );

                   var connectionPoolSettings = new ConnectionPoolSettings
                   {
                       MaxInProcessPerConnection = 32,
                       PoolSize = 4,
                       ReconnectionAttempts = 4,
                       ReconnectionBaseDelay = TimeSpan.FromSeconds(1)
                   };

                   return new GremlinClient(
                       gremlinServer: gremlinServer,
                       connectionPoolSettings: connectionPoolSettings
                   );
               }
           );

            container.AddSingleton(
                (serviceProvider) =>
                {
                    var gremlinClient = serviceProvider.GetService<GremlinClient>();
                    var driverRemoteConnection = new DriverRemoteConnection(gremlinClient, "g");

                    return AnonymousTraversalSource.Traversal().WithRemote(driverRemoteConnection);
                }
            );

            return container;
        }
    }
}
