using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Content.Infrastructure.Behaviours
{
    public static class IoCConfig
    {
        public static IServiceCollection AddMediatrBehaviours(this IServiceCollection container)
        {
            container.AddScoped(typeof(IPipelineBehavior<,>), typeof(MetricTracingBehavior<,>));

            return container;
        }
    }
}