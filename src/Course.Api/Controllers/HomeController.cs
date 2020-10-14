using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Course.Api API!");
    }
}