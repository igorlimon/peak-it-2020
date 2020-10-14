using Microsoft.AspNetCore.Mvc;

namespace Course.Identity.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Course.Notification API!");
    }
}