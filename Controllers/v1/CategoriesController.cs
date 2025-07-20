using Microsoft.AspNetCore.Mvc;

namespace VersionedApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("This is Categories v1");
    }
}