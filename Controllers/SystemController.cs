using AfroBeachApp.Data;
using AfroBeachApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AfroBeachApp.Controllers
{
    public class SystemController : Controller
    {
        private readonly AppDbContext _context;
        public SystemController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var systemInfo = _context.SystemInfos.ToList();
            return View(systemInfo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SystemInfo systemInfo, IFormFile file)
        {
            if (systemInfo != null)
            {
                if (file.Length > 100 * 1024)
                {
                    TempData["Message"] = "Picture size exceeds 100 kilobytes";
                }
                else
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        await file.CopyToAsync(memory);
                        byte[] imageData = memory.ToArray();
                        systemInfo.Logo = imageData;
                        await _context.SystemInfos.AddAsync(systemInfo);
                        await _context.SaveChangesAsync();
                        TempData["Message"] = "Record created successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            TempData["Message"] = "Error Creating Record";
            return View(systemInfo);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var system = _context.SystemInfos.FirstOrDefault(x => x.Id == Id);
            return View(system);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var system = _context.SystemInfos.FirstOrDefault(x => x.Id == Id);
            return View(system);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, SystemInfo systemInfo)
        {
            try
            {
                var existingSystem = await _context.SystemInfos.FirstOrDefaultAsync(x => x.Id == Id);
                if (existingSystem != null)
                {
                    existingSystem.ServiceHour = systemInfo.ServiceHour;
                    existingSystem.TelephoneNumber = systemInfo.TelephoneNumber;
                    existingSystem.TwitterUrl = systemInfo.TwitterUrl;
                    existingSystem.TikTokUrl = systemInfo.TikTokUrl;
                    existingSystem.Name = systemInfo.Name;
                    existingSystem.Address = systemInfo.Address;
                    existingSystem.EmailAddress = systemInfo.EmailAddress;
                    existingSystem.Description = systemInfo.Description;

                    _context.SystemInfos.Update(existingSystem);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Record updated successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Error: {ex.Message}";
            }
            return View(systemInfo);
        }
    }
}
