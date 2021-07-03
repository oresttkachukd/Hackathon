using Hackathon.Content.Application.UseCases.GetUserVideoPaths;
using Hackathon.Content.Application.UseCases.GetUserVideos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathon.Content.Api.Controllers
{
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/users/{userId:int}/videos")]
        public async Task<IActionResult> GetUserVideos(int userId, string priority)
        {
            var result = await _mediator.Send(new GetUserVideosQuery
            {
                UserId = userId,
                Priority = priority
            });

            return Ok(result);
        }

        [HttpGet("/users/{userId:int}/videos/{videoId:int}/paths")]
        public async Task<IActionResult> GetUserVideoPaths(int userId, int videoId, string priority)
        {
            var result = await _mediator.Send(new GetUserVideoPathsQuery
            {
                UserId = userId,
                VideoId = videoId,
                Priority = priority
            });

            return Ok(result);
        }
    }
}
