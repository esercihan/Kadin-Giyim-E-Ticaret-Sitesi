using eserProje.Data;
using eserProje.Models;
using eserProje.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eserProje.Controllers
{
    public class GiysiDetayController : Controller
    {
        private readonly eserDbContext _context;
        public GiysiDetayController(eserDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            GiysiDetayViewModel x = new GiysiDetayViewModel();
            x.Cloth = await _context.Clothes.Include(a => a.Category).FirstOrDefaultAsync(a => a.ClothID == id);
            x.Clothes= await _context.Clothes.Where(a => a.CategoryID == x.Cloth.CategoryID && a.ClothID != id).ToListAsync();
            return View(x);
        }
    }
}
