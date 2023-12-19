using AfroBeachApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace AfroBeachApp.Controllers
{
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
