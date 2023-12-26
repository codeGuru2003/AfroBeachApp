using AfroBeachApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AfroBeachApp.Controllers
{
    [Authorize(Roles = "Superadmin, Admin, Manager")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Default()
        {
            ViewData["productCount"] = _context.Products.Count();
            return View();
        }
    }
}
