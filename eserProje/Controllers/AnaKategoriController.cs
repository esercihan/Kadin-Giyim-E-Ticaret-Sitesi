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

namespace eserProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnaKategoriController : Controller
    {
        private readonly eserDbContext _context;

        public AnaKategoriController(eserDbContext context)
        {
            _context = context;
        }

        // GET: AnaKategori
        public async Task<IActionResult> Listele()
        {
            return View(await _context.MainCategories.ToListAsync());
        }

        // GET: AnaKategori/Detay/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null || _context.MainCategories == null)
            {
                return NotFound();
            }

            MainCategory mainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(m => m.MainCategoryID == id);
            if (mainCategory == null)
            {
                return NotFound();
            }

            return View(mainCategory);
        }

        // GET: AnaKategori/Ekle
        public IActionResult Ekle()
        {
            return View();
        }

        // POST: AnaKategori/Ekle
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("MainCategoryID,MainCategoryName")] MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listele));
            }
            return View(mainCategory);
        }

        // GET: AnaKategori/Duzenle/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null || _context.MainCategories == null)
            {
                return NotFound();
            }

            MainCategory mainCategory = await _context.MainCategories.FindAsync(id);
            if (mainCategory == null)
            {
                return NotFound();
            }
            return View(mainCategory);
        }

        // POST: AnaKategori/Duzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("MainCategoryID,MainCategoryName")] MainCategory mainCategory)
        {
            if (id != mainCategory.MainCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainCategoryExists(mainCategory.MainCategoryID))
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
            return View(mainCategory);
        }

        // GET: AnaKategori/Sil/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null || _context.MainCategories == null)
            {
                return NotFound();
            }

            MainCategory mainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(m => m.MainCategoryID == id);
            if (mainCategory == null)
            {
                return NotFound();
            }

            return View(mainCategory);
        }

        // POST: AnaKategori/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MainCategories == null)
            {
                return Problem("Entity set 'eserDbContext.MainCategories'  is null.");
            }
            MainCategory mainCategory = await _context.MainCategories.FindAsync(id);
            if (mainCategory != null)
            {
                _context.MainCategories.Remove(mainCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listele));
        }

        private bool MainCategoryExists(int id)
        {
            return _context.MainCategories.Any(e => e.MainCategoryID == id);
        }
    }
}
