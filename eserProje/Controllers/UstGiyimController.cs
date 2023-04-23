using eserProje.Data;
using eserProje.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace eserProje.Controllers
{
    public class UstGiyimController : Controller
    {
        private readonly eserDbContext _context;
        public UstGiyimController(eserDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a=>a.Category.MainCategoryID==1).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Abiye()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 1 && a.Category.CategoryID==1).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Elbise()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 1 && a.Category.CategoryID == 2).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Takim()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 1 && a.Category.CategoryID == 3).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Tulum()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 1 && a.Category.CategoryID == 4).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Bluz()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 1 && a.Category.CategoryID == 5).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Gomlek()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 1 && a.Category.CategoryID == 6).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> TShirt()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 1 && a.Category.CategoryID == 7).ToListAsync();

            return View(x);
        }
    }
}
