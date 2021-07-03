using Gremlin.Net.Driver;
using Gremlin.Net.Process.Traversal;
using Hackathon.Content.Application.UseCases.GetUserVideos;
using Hackathon.Content.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hackathon.Content.Infrastructure.Persistance.Gremlin.QueryHandlers
{
    public class GetUserVideosQueryHandler : IRequestHandler<GetUserVideosQuery, VideoDto[]>
    {        
        private readonly IGremlinClient _gremlinClient;

        public GetUserVideosQueryHandler(IGremlinClient gremlinClient)
        {            
            _gremlinClient = gremlinClient;
        }

        public Task<VideoDto[]> Handle(GetUserVideosQuery request, CancellationToken cancellationToken)
        {            
            return Task.FromResult(Array.Empty<VideoDto>());
        }
    }
}
