using Microsoft.AspNetCore.Mvc;
using VersionedApi.Models.v2;

namespace VersionedApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/events")]
    [Consumes("application/xml")]
    [Produces("application/xml")]
    public class EventsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] EventRequest request)
        {
            return Ok($"[v2] Received '{request.Name}' with date '{request.EventDate:u}' (DateTime)");
        }

        [HttpGet]
        [Produces("application/xml")]
        public ActionResult<EventRequest> Get()
        {
            return Ok(new EventRequest
            {
                Name = "Sample",
                EventDate = DateTime.UtcNow
            });
        }
    }
}
