using AfroBeachApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AfroBeachApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public AdminController()
        {
            
        }
        public IActionResult Default()
        {
            return View();
        }
    }
}
