using MediatR;

namespace Hackathon.Content.Application.UseCases.GetUserVideos
{
    public class GetUserVideosQuery : IRequest<VideoDto[]>
    {
        public int UserId { get; set; }

        public string Priority { get; set; }
    }
}
