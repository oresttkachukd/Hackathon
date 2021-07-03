using Gremlin.Net.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Content.Infrastructure.Persistance.Gremlin
{
    public static class IoCConfig
    {
        private static List<string> OutOfTimeDataPopulationQueries = new List<string>()
        {
            "g.V().drop();",
            "g.addV('user').property('id', '1')",
            "g.addV('user').property('id', '2')",
            "g.addV('user').property('id', '3')",
            "g.addV('user').property('id', '4')",
            "g.addV('user').property('id', '5')",
            "g.addV('user').property('id', '6')",
            "g.addV('user').property('id', '7')",
            "g.addV('user').property('id', '8')",
            "g.addV('user').property('id', '9')",
            "g.addV('user').property('id', '10')",
            "g.addV('video').property('id', '1')",
            "g.addV('video').property('id', '2').property('name', 'Video 2')",
            "g.addV('video').property('id', '3').property('name', 'Video 3')",
            "g.addV('video').property('id', '4').property('name', 'Video 4')",
            "g.addV('video').property('id', '5').property('name', 'Video 5')",
            "g.addV('video').property('id', '6').property('name', 'Video 6')",
            "g.addV('video').property('id', '7').property('name', 'Video 7')",
            "g.addV('video').property('id', '8').property('name', 'Video 8')",
            "g.addV('video').property('id', '9').property('name', 'Video 9')",
            "g.addV('video').property('id', '10').property('name', 'Video 10')",
            "g.addV('video').property('id', '11').property('name', 'Video 11')",
            "g.addV('video').property('id', '12').property('name', 'Video 12')",
            "g.addV('video').property('id', '13').property('name', 'Video 13')",
            "g.addV('video').property('id', '14').property('name', 'Video 14')",
            "g.addV('video').property('id', '15').property('name', 'Video 15')",
            "g.addV('video').property('id', '16').property('name', 'Video 16')",
            "g.addV('video').property('id', '17').property('name', 'Video 17')",
            "g.addV('video').property('id', '18').property('name', 'Video 18')",
            "g.addV('video').property('id', '19').property('name', 'Video 19')",
            "g.addV('video').property('id', '20').property('name', 'Video 20')",
            "g.addV('video').property('id', '21').property('name', 'Video 21')",
            "g.addV('video').property('id', '22').property('name', 'Video 22')",
            "g.addV('video').property('id', '23').property('name', 'Video 23')",
            "g.addV('video').property('id', '24').property('name', 'Video 24')",
            "g.addV('video').property('id', '25').property('name', 'Video 25')",
            "g.addV('video').property('id', '26').property('name', 'Video 26')",
            "g.addV('video').property('id', '27').property('name', 'Video 27')",
            "g.addV('video').property('id', '28').property('name', 'Video 28')",
            "g.addV('video').property('id', '29').property('name', 'Video 29')",
            "g.addV('video').property('id', '30').property('name', 'Video 30')",
            "g.addV('group').property('id', '1')",
            "g.addV('group').property('id', '2')",
            "g.addV('group').property('id', '3')",
            "g.addV('group').property('id', '4')",
            "g.addV('group').property('id', '5')",
            "g.addV('group').property('id', '6')",
            "g.addV('group').property('id', '7')",
            "g.addV('group').property('id', '8')",
            "g.addV('group').property('id', '9')",
            "g.addV('flow').property('id', '1')",
            "g.addV('flow').property('id', '2')",
            "g.addV('flow').property('id', '3')",
            "g.addV('flow').property('id', '4')",
            "g.addV('flow').property('id', '5')",
            "g.addV('flow').property('id', '6')",
            "g.addV('flow').property('id', '7')",
            "g.addV('flow').property('id', '8')",
            "g.addV('flow').property('id', '9')",
            "g.addV('flow').property('id', '10')",
            "g.addV('flow').property('id', '11')",
            "g.addV('flow').property('id', '12')",
            "g.V(g.V().has('user', 'id', '1').next()).addE('associates').to(g.V().has('video', 'id', '1').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '2').next()).addE('associates').to(g.V().has('video', 'id', '2').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '3').next()).addE('associates').to(g.V().has('video', 'id', '3').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '4').next()).addE('associates').to(g.V().has('video', 'id', '4').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '5').next()).addE('associates').to(g.V().has('video', 'id', '5').next()).property('priority', 'medium')",
            "g.V(g.V().has('user', 'id', '5').next()).addE('associates').to(g.V().has('video', 'id', '6').next()).property('priority', 'high')",
            "g.V(g.V().has('user', 'id', '5').next()).addE('associates').to(g.V().has('video', 'id', '7').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '15').next()).property('priority', 'medium')",
            "g.V(g.V().has('user', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '16').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '17').next()).property('priority', 'high')",
            "g.V(g.V().has('user', 'id', '8').next()).addE('associates').to(g.V().has('video', 'id', '16').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '8').next()).addE('associates').to(g.V().has('video', 'id', '21').next()).property('priority', 'medium')",
            "g.V(g.V().has('user', 'id', '8').next()).addE('associates').to(g.V().has('video', 'id', '22').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '8').next()).addE('associates').to(g.V().has('video', 'id', '23').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '10').next()).addE('associates').to(g.V().has('video', 'id', '30').next()).property('priority', 'critical')",

            "g.V(g.V().has('user', 'id', '2').next()).addE('associates').to(g.V().has('group', 'id', '1').next())",
            "g.V(g.V().has('user', 'id', '3').next()).addE('associates').to(g.V().has('group', 'id', '2').next())",
            "g.V(g.V().has('user', 'id', '4').next()).addE('associates').to(g.V().has('group', 'id', '3').next())",
            "g.V(g.V().has('user', 'id', '4').next()).addE('associates').to(g.V().has('group', 'id', '4').next())",
            "g.V(g.V().has('user', 'id', '5').next()).addE('associates').to(g.V().has('group', 'id', '5').next())",
            "g.V(g.V().has('user', 'id', '6').next()).addE('associates').to(g.V().has('group', 'id', '6').next())",
            "g.V(g.V().has('user', 'id', '7').next()).addE('associates').to(g.V().has('group', 'id', '7').next())",
            "g.V(g.V().has('user', 'id', '8').next()).addE('associates').to(g.V().has('group', 'id', '7').next())",
            "g.V(g.V().has('user', 'id', '8').next()).addE('associates').to(g.V().has('group', 'id', '9').next())",
            "g.V(g.V().has('user', 'id', '9').next()).addE('associates').to(g.V().has('group', 'id', '7').next())",
            "g.V(g.V().has('user', 'id', '9').next()).addE('associates').to(g.V().has('group', 'id', '8').next())",
            "g.V(g.V().has('user', 'id', '10').next()).addE('associates').to(g.V().has('group', 'id', '7').next())",

            "g.V(g.V().has('user', 'id', '3').next()).addE('associates').to(g.V().has('flow', 'id', '1').next()).property('priority', 'critical')",
            "g.V(g.V().has('user', 'id', '4').next()).addE('associates').to(g.V().has('flow', 'id', '2').next()).property('priority', 'critical')",
            "g.V(g.V().has('user', 'id', '5').next()).addE('associates').to(g.V().has('flow', 'id', '4').next()).property('priority', 'medium')",
            "g.V(g.V().has('user', 'id', '6').next()).addE('associates').to(g.V().has('flow', 'id', '5').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '6').next()).addE('associates').to(g.V().has('flow', 'id', '6').next()).property('priority', 'high')",
            "g.V(g.V().has('user', 'id', '7').next()).addE('associates').to(g.V().has('flow', 'id', '7').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '7').next()).addE('associates').to(g.V().has('flow', 'id', '8').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '7').next()).addE('associates').to(g.V().has('flow', 'id', '9').next()).property('priority', 'medium')",
            "g.V(g.V().has('user', 'id', '9').next()).addE('associates').to(g.V().has('flow', 'id', '12').next()).property('priority', 'low')",
            "g.V(g.V().has('user', 'id', '10').next()).addE('associates').to(g.V().has('flow', 'id', '11').next()).property('priority', 'high')",

            "g.V(g.V().has('group', 'id', '1').next()).addE('associates').to(g.V().has('video', 'id', '2').next()).property('priority', 'high')",
            "g.V(g.V().has('group', 'id', '2').next()).addE('associates').to(g.V().has('video', 'id', '3').next()).property('priority', 'high')",
            "g.V(g.V().has('group', 'id', '3').next()).addE('associates').to(g.V().has('video', 'id', '4').next()).property('priority', 'high')",
            "g.V(g.V().has('group', 'id', '5').next()).addE('associates').to(g.V().has('video', 'id', '8').next()).property('priority', 'medium')",
            "g.V(g.V().has('group', 'id', '6').next()).addE('associates').to(g.V().has('video', 'id', '9').next()).property('priority', 'high')",
            "g.V(g.V().has('group', 'id', '6').next()).addE('associates').to(g.V().has('video', 'id', '12').next()).property('priority', 'low')",
            "g.V(g.V().has('group', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '22').next()).property('priority', 'medium')",
            "g.V(g.V().has('group', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '24').next()).property('priority', 'high')",
            "g.V(g.V().has('group', 'id', '9').next()).addE('associates').to(g.V().has('video', 'id', '15').next()).property('priority', 'critical')",
            "g.V(g.V().has('group', 'id', '9').next()).addE('associates').to(g.V().has('video', 'id', '16').next()).property('priority', 'critical')",
            "g.V(g.V().has('group', 'id', '9').next()).addE('associates').to(g.V().has('video', 'id', '17').next()).property('priority', 'critical')",

            "g.V(g.V().has('group', 'id', '4').next()).addE('associates').to(g.V().has('flow', 'id', '3').next()).property('priority', 'medium')",
            "g.V(g.V().has('group', 'id', '5').next()).addE('associates').to(g.V().has('flow', 'id', '4').next()).property('priority', 'high')",
            "g.V(g.V().has('group', 'id', '7').next()).addE('associates').to(g.V().has('flow', 'id', '10').next()).property('priority', 'high')",
            "g.V(g.V().has('group', 'id', '8').next()).addE('associates').to(g.V().has('flow', 'id', '11').next()).property('priority', 'medium')",
            "g.V(g.V().has('group', 'id', '8').next()).addE('associates').to(g.V().has('flow', 'id', '12').next()).property('priority', 'high')",

            "g.V(g.V().has('flow', 'id', '1').next()).addE('associates').to(g.V().has('video', 'id', '3').next())",
            "g.V(g.V().has('flow', 'id', '3').next()).addE('associates').to(g.V().has('video', 'id', '4').next())",
            "g.V(g.V().has('flow', 'id', '4').next()).addE('associates').to(g.V().has('video', 'id', '5').next())",
            "g.V(g.V().has('flow', 'id', '4').next()).addE('associates').to(g.V().has('video', 'id', '7').next())",
            "g.V(g.V().has('flow', 'id', '5').next()).addE('associates').to(g.V().has('video', 'id', '9').next())",
            "g.V(g.V().has('flow', 'id', '5').next()).addE('associates').to(g.V().has('video', 'id', '10').next())",
            "g.V(g.V().has('flow', 'id', '5').next()).addE('associates').to(g.V().has('video', 'id', '11').next())",
            "g.V(g.V().has('flow', 'id', '6').next()).addE('associates').to(g.V().has('video', 'id', '12').next())",
            "g.V(g.V().has('flow', 'id', '6').next()).addE('associates').to(g.V().has('video', 'id', '13').next())",
            "g.V(g.V().has('flow', 'id', '6').next()).addE('associates').to(g.V().has('video', 'id', '14').next())",
            "g.V(g.V().has('flow', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '18').next())",
            "g.V(g.V().has('flow', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '19').next())",
            "g.V(g.V().has('flow', 'id', '7').next()).addE('associates').to(g.V().has('video', 'id', '20').next())",
            "g.V(g.V().has('flow', 'id', '8').next()).addE('associates').to(g.V().has('video', 'id', '21').next())",
            "g.V(g.V().has('flow', 'id', '8').next()).addE('associates').to(g.V().has('video', 'id', '22').next())",
            "g.V(g.V().has('flow', 'id', '8').next()).addE('associates').to(g.V().has('video', 'id', '23').next())",
            "g.V(g.V().has('flow', 'id', '9').next()).addE('associates').to(g.V().has('video', 'id', '23').next())",
            "g.V(g.V().has('flow', 'id', '9').next()).addE('associates').to(g.V().has('video', 'id', '24').next())",
            "g.V(g.V().has('flow', 'id', '9').next()).addE('associates').to(g.V().has('video', 'id', '25').next())",
            "g.V(g.V().has('flow', 'id', '10').next()).addE('associates').to(g.V().has('video', 'id', '26').next())",
            "g.V(g.V().has('flow', 'id', '10').next()).addE('associates').to(g.V().has('video', 'id', '27').next())",
            "g.V(g.V().has('flow', 'id', '10').next()).addE('associates').to(g.V().has('video', 'id', '28').next())",
            "g.V(g.V().has('flow', 'id', '11').next()).addE('associates').to(g.V().has('video', 'id', '15').next())",
            "g.V(g.V().has('flow', 'id', '11').next()).addE('associates').to(g.V().has('video', 'id', '16').next())",
            "g.V(g.V().has('flow', 'id', '11').next()).addE('associates').to(g.V().has('video', 'id', '17').next())",
            "g.V(g.V().has('flow', 'id', '12').next()).addE('associates').to(g.V().has('video', 'id', '29').next())",
            "g.V(g.V().has('flow', 'id', '12').next()).addE('associates').to(g.V().has('video', 'id', '30').next())"
        };

        public static IServiceCollection AddGremlinPersistence(this IServiceCollection container, IConfiguration configuration)
        {
            var gremlinSettings = configuration.GetSection("Gremlin").Get<GremlinSettings>();
            if (gremlinSettings == null)
            {
                throw new Exception($"{nameof(GremlinSettings)} are not configured");
            }

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

            var client = new GremlinClient(
                gremlinServer: gremlinServer,
                connectionPoolSettings: connectionPoolSettings
            );

            var initializationTasks = OutOfTimeDataPopulationQueries.Select(x => client.SubmitAsync(x));
            Task.WhenAll(initializationTasks).GetAwaiter().GetResult();

            container.AddSingleton<IGremlinClient>(client);                

            return container;
        }
    }
}
