using eserProje.Data;
using eserProje.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eserProje.Controllers
{
    public class DisGiyimController : Controller
    {
        private readonly eserDbContext _context;
        public DisGiyimController(eserDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 2).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Ceket()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 2 && a.Category.CategoryID == 8).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Trenckot()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 2 && a.Category.CategoryID == 9).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> Yelek()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 2 && a.Category.CategoryID == 10).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> KotCeket()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 2 && a.Category.CategoryID == 11).ToListAsync();

            return View(x);
        }

        public async Task<IActionResult> MontKaban()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Clothes = await _context.Clothes.Where(a => a.Category.MainCategoryID == 2 && a.Category.CategoryID == 12).ToListAsync();

            return View(x);
        }

    }
}
