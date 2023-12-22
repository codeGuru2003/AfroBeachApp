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
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.CurrencyOne).Include(p => p.CurrencyTwo).Include(p => p.ProductCategory);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.CurrencyOne)
                .Include(p => p.CurrencyTwo)
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CurrencyOneID"] = new SelectList(_context.Currencies, "Id", "Code");
            ViewData["CurrencyTwoID"] = new SelectList(_context.Currencies, "Id", "Code");
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductCategoryID,Name,ShortDescription,Description,Image1,Image2,Image3,Image4,CurrencyOneID,CurrencyOneAmount,CurrencyTwoID,CurrencyTwoAmount,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,DeletedBy,DeletedOn,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrencyOneID"] = new SelectList(_context.Currencies, "Id", "Code", product.CurrencyOneID);
            ViewData["CurrencyTwoID"] = new SelectList(_context.Currencies, "Id", "Code", product.CurrencyTwoID);
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategories, "Id", "Name", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CurrencyOneID"] = new SelectList(_context.Currencies, "Id", "Code", product.CurrencyOneID);
            ViewData["CurrencyTwoID"] = new SelectList(_context.Currencies, "Id", "Code", product.CurrencyTwoID);
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategories, "Id", "Name", product.ProductCategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductCategoryID,Name,ShortDescription,Description,Image1,Image2,Image3,Image4,CurrencyOneID,CurrencyOneAmount,CurrencyTwoID,CurrencyTwoAmount,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,DeletedBy,DeletedOn,IsDeleted")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CurrencyOneID"] = new SelectList(_context.Currencies, "Id", "Code", product.CurrencyOneID);
            ViewData["CurrencyTwoID"] = new SelectList(_context.Currencies, "Id", "Code", product.CurrencyTwoID);
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategories, "Id", "Name", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.CurrencyOne)
                .Include(p => p.CurrencyTwo)
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
