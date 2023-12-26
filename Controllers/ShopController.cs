using AfroBeachApp.Data;
using AfroBeachApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AfroBeachApp.Controllers
{
	public class ShopController : Controller
	{

		private readonly AppDbContext _context;

		public ShopController(AppDbContext context)
		{
			_context = context;
		}


		public async Task<IActionResult> Index(string productCategory)
		{
			var category = await _context.ProductCategories.ToArrayAsync();
			List<Product> products;

			if (string.IsNullOrWhiteSpace(productCategory))
			{
				products = await _context.Products.ToListAsync();
			} else
			{
				var categoryid = _context.ProductCategories.Where(x => x.Name == productCategory).FirstOrDefault();
				products = await _context.Products.Where(x => x.ProductCategoryID == categoryid.Id).ToListAsync(); ;
			}
			
			



			ViewData["ProductCategory"] = category;

			return View(products);
		}
	}
}
