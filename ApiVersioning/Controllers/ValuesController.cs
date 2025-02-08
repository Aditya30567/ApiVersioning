using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet("gretting")]
        [MapToApiVersion("1.0")]
        public string Gretting()
        {
            return "Hello world";
        }
        [HttpGet("today")]
        [MapToApiVersion("1.0")]
        public string GetToday()
        {
            return DateTime.Now.ToString();
        }
        [HttpGet("tomorrow")]
        [MapToApiVersion("2.0")]
        public string GetTomorrow()
        {
            return DateTime.Now.AddDays(1).ToString();
        }
    }
}
