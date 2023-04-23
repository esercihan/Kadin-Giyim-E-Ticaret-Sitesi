using eserProje.Data;
using eserProje.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eserProje.Controllers
{
    public class AltGiyimController : Controller
    {
        private readonly eserDbContext _context;
        public AltGiyimController(eserDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 3).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Pantolon()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 3 && a.Category.CategoryID == 13).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> JeanPantolon()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 3 && a.Category.CategoryID == 14).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Etek()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 3 && a.Category.CategoryID == 15).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Tayt()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 3 && a.Category.CategoryID == 16).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Esofman()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 3 && a.Category.CategoryID == 17).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Sort()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 3 && a.Category.CategoryID == 18).ToListAsync();

            return View(x);
        }
    }
}
