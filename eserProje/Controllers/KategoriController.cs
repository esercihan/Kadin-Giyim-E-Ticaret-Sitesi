using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eserProje.Data;
using eserProje.Models;
using Microsoft.AspNetCore.Authorization;
using eserProje.ViewModel;

namespace eserProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KategoriController : Controller
    {
        private readonly eserDbContext _context;

        public KategoriController(eserDbContext context)
        {
            _context = context;
        }

        // GET: Kategori
        public async Task<IActionResult> Listele()
        {
            var eserDbContext = _context.Categories.Include(c => c.MainCategory);
            return View(await eserDbContext.ToListAsync());
        }

        // GET: Kategori/Detay/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            Category category = await _context.Categories
                .Include(c => c.MainCategory)
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Kategori/Ekle
        public IActionResult Ekle()
        {
            CategoryViewModel x = new CategoryViewModel();
            x.MainCategories = _context.MainCategories.ToList();
            x.Category = new Category();
            return View(x);
        }

        // POST: Kategori/Ekle
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("CategoryID,CategoryName,MainCategoryID")] Category category)
        {
            CategoryViewModel x = new CategoryViewModel();
            x.Category = category;
            x.MainCategories = await _context.MainCategories.ToListAsync();
           
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listele));
            }

            return View(x);
        }

        // GET: Kategori/Duzenle/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            CategoryViewModel x = new CategoryViewModel();
            x.MainCategories = await _context.MainCategories.ToListAsync();
            x.Category = await _context.Categories.FindAsync(id);

            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Kategori/Duzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("CategoryID,CategoryName,MainCategoryID")] Category category)
        {
            if (id != category.CategoryID)
            {
                return NotFound();
            }

            CategoryViewModel x = new CategoryViewModel();
            x.MainCategories = await _context.MainCategories.ToListAsync();
            x.Category = category;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Listele));
            }

            return View(x);
        }

        // GET: Kategori/Sil/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.MainCategory)
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Kategori/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'eserDbContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listele));
        }

        private bool CategoryExists(int id)
        {
          return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
