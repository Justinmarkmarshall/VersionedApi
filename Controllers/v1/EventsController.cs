using Microsoft.AspNetCore.Mvc;
using VersionedApi.Models.v1;

namespace VersionedApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/events")]
    [Consumes("application/xml")]
    public class EventsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] EventRequest request)
        {
            return Ok($"[v1] Received '{request.Name}' with date '{request.EventDate}' (string)");
        }
    }
}
