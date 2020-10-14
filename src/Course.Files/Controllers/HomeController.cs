using Microsoft.AspNetCore.Mvc;

namespace Course.Files.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Course.Files API!");
    }
}