using eserProje.Data;
using eserProje.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eserProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly eserDbContext _context;
        public HomeController(eserDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel x = new HomeViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.MainCategories = await _context.MainCategories.ToListAsync();
            x.Clothes = await _context.Clothes.OrderByDescending(x => x.ClothID).Take(12).ToListAsync();
          
            
            return View(x);
        }


        public async Task<IActionResult> Ara(string arama = "")
        {
            HomeViewModel x = new HomeViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.MainCategories = await _context.MainCategories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.ClothName.ToUpper().Contains(arama) || arama == "").ToListAsync();
            

            return View(x);
        }
        public IActionResult Arama(string aranacak)
        {
            return RedirectToAction("Ara","Home",new { arama=aranacak.ToUpper() });
        }


    }
}
