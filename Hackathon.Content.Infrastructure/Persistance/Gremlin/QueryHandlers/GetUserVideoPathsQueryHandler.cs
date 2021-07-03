using Hackathon.Content.Application.UseCases.GetUserVideoPaths;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hackathon.Content.Infrastructure.Persistance.Gremlin.QueryHandlers
{
    public class GetUserVideoPathsQueryHandler : IRequestHandler<GetUserVideoPathsQuery, VideoPathDto[]>
    {
        public Task<VideoPathDto[]> Handle(GetUserVideoPathsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
