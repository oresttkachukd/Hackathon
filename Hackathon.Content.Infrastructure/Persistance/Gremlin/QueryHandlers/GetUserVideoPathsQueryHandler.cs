using Gremlin.Net.Driver;
using Hackathon.Content.Application.UseCases.GetUserVideoPaths;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hackathon.Content.Infrastructure.Persistance.Gremlin.QueryHandlers
{
    public class GetUserVideoPathsQueryHandler : IRequestHandler<GetUserVideoPathsQuery, VideoPathDto[]>
    {
        private readonly IGremlinClient _gremlinClient;

        public GetUserVideoPathsQueryHandler(IGremlinClient gremlinClient)
        {
            _gremlinClient = gremlinClient;
        }

        public async Task<VideoPathDto[]> Handle(GetUserVideoPathsQuery request, CancellationToken cancellationToken)
        {
            var parameters = new Dictionary<string, object>
            {
                { "userid", request.UserId.ToString() },
                { "videoId", request.VideoId.ToString() },
                { "priority", request.Priority }
            };
            
            var responses = await _gremlinClient.SubmitAsync<dynamic>("g.V().has('user', 'id', userid).repeat(out('associates')).until(has('video','id', videoId)).path().by('id').by(label)", parameters);

            var result = new List<VideoPathDto>();

            foreach (var response in responses)
            {
                if(response.Objects is object[])
                {
                    var objects = response.Objects as object[];

                    result.Add(new VideoPathDto
                    {
                        Path = string.Join("/", objects.Select(x => x is string ? (x as string) : string.Empty).ToArray())
                    });
                }                    
            }

            return result.ToArray();
        }
    }
}
