using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ControllerName("Home")]
    [Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("3.0")]
    public class HomeV3Controller1 : ControllerBase
    {
        [HttpGet("Welcome/{name}")]
        [MapToApiVersion("3.0")]
        [Obsolete("This is message is derprecated version",true)]
        public IActionResult Welcome(string name)
        {
            return Ok("Hello world" + name);
        }
    }
}
