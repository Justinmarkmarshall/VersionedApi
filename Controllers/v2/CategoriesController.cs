using Microsoft.AspNetCore.Mvc;

namespace VersionedApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/categories")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("This is Categories v2");
    }
}