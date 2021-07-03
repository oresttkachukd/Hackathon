using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Content.Api.Controllers
{    
    [ApiController]
    public class PathController : ControllerBase
    {
        [HttpGet("/users/{userId:int}/videos/{videoId:int}/paths")]
        public ActionResult GetUserVideoPaths(string priority)
        {
            return Ok();
        }
    }
}
