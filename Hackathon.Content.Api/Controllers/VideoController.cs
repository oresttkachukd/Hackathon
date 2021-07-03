using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Content.Api.Controllers
{
    [ApiController]
    public class VideoController : ControllerBase
    {       
        [HttpGet("/users/{userId:int}/videos")]
        public ActionResult GetUserVideos(string priority)
        {
            return Ok();
        }

        [HttpGet("/users/{userId:int}/videos/{videoId:int}/paths")]
        public ActionResult GetUserVideoPaths(string priority)
        {
            return Ok();
        }
    }
}
