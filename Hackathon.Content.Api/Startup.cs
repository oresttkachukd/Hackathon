using Hackathon.Content.Infrastructure.Persistance.Gremlin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using System.Reflection;
using System.Linq;
using Hackathon.Content.Infrastructure.Messaging.RabbitMq;
using Hackathon.Content.Infrastructure.Behaviours;

namespace Hackathon.Content.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load).ToArray());

            services.AddMediatrBehaviours();

            services.AddGremlinPersistence(_configuration);

            services.AddRabbitMqMessaging(_configuration);      
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
