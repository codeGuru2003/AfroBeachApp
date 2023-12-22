using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AfroBeachApp.Data;
using AfroBeachApp.Models;

namespace AfroBeachApp.Controllers
{
    public class SocialGalleriesController : Controller
    {
        private readonly AppDbContext _context;

        public SocialGalleriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SocialGalleries
        public async Task<IActionResult> Index()
        {
              return _context.SocialGalleries != null ? 
                          View(await _context.SocialGalleries.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.SocialGalleries'  is null.");
        }

        // GET: SocialGalleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SocialGalleries == null)
            {
                return NotFound();
            }

            var socialGallery = await _context.SocialGalleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialGallery == null)
            {
                return NotFound();
            }

            return View(socialGallery);
        }

        // GET: SocialGalleries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialGalleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image1,Image2,Image3,Image4,Image5,Image6")] SocialGallery socialGallery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialGallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialGallery);
        }

        // GET: SocialGalleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SocialGalleries == null)
            {
                return NotFound();
            }

            var socialGallery = await _context.SocialGalleries.FindAsync(id);
            if (socialGallery == null)
            {
                return NotFound();
            }
            return View(socialGallery);
        }

        // POST: SocialGalleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image1,Image2,Image3,Image4,Image5,Image6")] SocialGallery socialGallery)
        {
            if (id != socialGallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialGallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialGalleryExists(socialGallery.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(socialGallery);
        }

        // GET: SocialGalleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SocialGalleries == null)
            {
                return NotFound();
            }

            var socialGallery = await _context.SocialGalleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialGallery == null)
            {
                return NotFound();
            }

            return View(socialGallery);
        }

        // POST: SocialGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SocialGalleries == null)
            {
                return Problem("Entity set 'AppDbContext.SocialGalleries'  is null.");
            }
            var socialGallery = await _context.SocialGalleries.FindAsync(id);
            if (socialGallery != null)
            {
                _context.SocialGalleries.Remove(socialGallery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialGalleryExists(int id)
        {
          return (_context.SocialGalleries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
