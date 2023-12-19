using Microsoft.AspNetCore.Mvc;

namespace AfroBeachApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult PageNotFound()
        {
            return View("404");
        }
    }
}
