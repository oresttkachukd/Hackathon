using Gremlin.Net.Process.Traversal;
using Hackathon.Content.Application.UseCases.GetUserVideos;
using Hackathon.Content.Core;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hackathon.Content.Infrastructure.Persistance.Gremlin.QueryHandlers
{
    public class GetUserVideosQueryHandler : IRequestHandler<GetUserVideosQuery, VideoDto[]>
    {
        private readonly GraphTraversalSource _g;

        public GetUserVideosQueryHandler(GraphTraversalSource g)
        {
            _g = g;
        }

        public Task<VideoDto[]> Handle(GetUserVideosQuery request, CancellationToken cancellationToken)
        {
            var created = _g.AddV(nameof(User)).With(nameof(User.Id), 1);

            return Task.FromResult(Array.Empty<VideoDto>());
        }
    }
}
