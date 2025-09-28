using Microsoft.AspNetCore.Mvc;

namespace EulersIdentity.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Hello from API";
    }
}