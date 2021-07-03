using Hackathon.Content.Application.Services;
using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Hackathon.Content.Infrastructure.Behaviours
{
    public class MetricTracingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IMessageBroker _messageBroker;

        public MetricTracingBehavior(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = Stopwatch.StartNew();

            var response = await next();

            stopwatch.Stop();

            await _messageBroker.Publish(new MetricTraced
            {
                ItemsCount = response is object[]? (response as object[]).Length : 0,
                ElapsedTime = stopwatch.ElapsedMilliseconds
            });

            return response;
        }
    }
}
