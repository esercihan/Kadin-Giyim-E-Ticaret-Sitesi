using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eserProje.Data;
using eserProje.Models;
using eserProje.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace eserProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GiysiController : Controller
    {
        private readonly eserDbContext _context;

        public GiysiController(eserDbContext context)
        {
            _context = context;
        }

        // GET: Giysi
        public async Task<IActionResult> Listele()
        {
            var eserDbContext = _context.Clothes.Include(c => c.Category);
            return View(await eserDbContext.ToListAsync());
        }

        // GET: Giysi/Detay/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            Cloth cloth = await _context.Clothes
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ClothID == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // GET: Giysi/Ekle
        public IActionResult Ekle()
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = _context.Categories.ToList();
            x.Cloth = new Cloth();
            return View(x);
        }

        // POST: Giysi/Ekle
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("ClothName,Price,Description,CategoryID")] Cloth cloth)
        {
            GiysiViewModel x = new GiysiViewModel();
            x.Cloth = cloth;
            x.Categories = await _context.Categories.ToListAsync();

            if (ModelState.IsValid)
            {
                _context.Add(cloth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listele));
            }
            return View(x);
        }

        // GET: Giysi/Duzenle/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }
            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Cloth = await _context.Clothes.FindAsync(id);
            

            Cloth cloth = await _context.Clothes.FindAsync(id);
            if (cloth == null)
            {
                return NotFound();
            }
            return View(x);
        }

        // POST: Giysi/Duzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("ClothID,ClothName,Price,Description,CategoryID")] Cloth cloth)
        {
            if (id != cloth.ClothID)
            {
                return NotFound();
            }

            GiysiViewModel x = new GiysiViewModel();
            x.Categories = await _context.Categories.ToListAsync();
            x.Cloth = cloth;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cloth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothExists(cloth.ClothID))
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

        // GET: Giysi/Sil/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            Cloth cloth = await _context.Clothes
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ClothID == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // POST: Giysi/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clothes == null)
            {
                return Problem("Entity set 'eserDbContext.Clothes'  is null.");
            }
            Cloth cloth = await _context.Clothes.FindAsync(id);
            if (cloth != null)
            {
                _context.Clothes.Remove(cloth);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listele));
        }

        private bool ClothExists(int id)
        {
          return _context.Clothes.Any(e => e.ClothID == id);
        }
    }
}
