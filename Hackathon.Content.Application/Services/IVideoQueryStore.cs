using Hackathon.Content.Application.UseCases.GetUserVideoPaths;
using Hackathon.Content.Application.UseCases.GetUserVideos;

namespace Hackathon.Content.Application.Services
{
    public interface IVideoQueryStore
    {
        VideoDto[] Get(GetUserVideosQuery query);

        VideoPathDto[] Get(GetUserVideoPathsQuery query);      
    }
}
