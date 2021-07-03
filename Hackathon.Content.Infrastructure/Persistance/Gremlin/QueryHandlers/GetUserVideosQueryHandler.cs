using Gremlin.Net.Driver;
using Hackathon.Content.Application.UseCases.GetUserVideos;
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

        public async Task<VideoDto[]> Handle(GetUserVideosQuery request, CancellationToken cancellationToken)
        {
            var parameters = new Dictionary<string, object>
            {
                { "userid", request.UserId },
                { "priority", request.Priority }
            };
            var response = await _gremlinClient.SubmitAsync<dynamic>("g.V().has('user', 'id', userid).out('associates').valueMap()", parameters);
           
            return Array.Empty<VideoDto>();
        }
    }
}
