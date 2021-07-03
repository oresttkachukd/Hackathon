using MediatR;

namespace Hackathon.Content.Application.UseCases.GetUserVideoPaths
{
    public class GetUserVideoPathsQuery : IRequest<VideoPathDto[]>
    {
        public int UserId { get; set; }

        public int VideoId { get; set; }

        public string Priority { get; set; }
    }
}
