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
    public class BegeniController : Controller
    {
        private readonly eserDbContext _context;

        public BegeniController(eserDbContext context)
        {
            _context = context;
        }

        // GET: Begeni
        public async Task<IActionResult> Listele()
        {
            var eserDbContext = _context.Likees.Include(l => l.Cloth).Include(l => l.Userr);
            return View(await eserDbContext.ToListAsync());
        }

        // GET: Begeni/Detay/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null || _context.Likees == null)
            {
                return NotFound();
            }

            Likee likee = await _context.Likees
                .Include(l => l.Cloth)
                .Include(l => l.Userr)
                .FirstOrDefaultAsync(m => m.LikeeID == id);
            if (likee == null)
            {
                return NotFound();
            }

            return View(likee);
        }

        // GET: Begeni/Ekle
        public IActionResult Ekle()
        {
            LikeViewModel x = new LikeViewModel();
            x.Userrs = _context.Userrs.ToList();
            x.Clothes = _context.Clothes.ToList();
            x.Likee = new Likee();
            return View(x);
        }

        // POST: Begeni/Ekle
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("LikeeID,UserrID,ClothID,LikeeDate")] Likee likee)
        {
            LikeViewModel x = new LikeViewModel();
            x.Likee = likee;
            x.Userrs = await _context.Userrs.ToListAsync();
            x.Clothes = await _context.Clothes.ToListAsync();

            if (ModelState.IsValid)
            {
                _context.Add(likee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listele));
            }

            return View(x);
        }

        // GET: Begeni/Duzenle/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null || _context.Likees == null)
            {
                return NotFound();
            }
            LikeViewModel x = new LikeViewModel();
            x.Userrs = await _context.Userrs.ToListAsync();
            x.Clothes = await _context.Clothes.ToListAsync();
            x.Likee = await _context.Likees.FindAsync(id);

            Likee likee = await _context.Likees.FindAsync(id);
            if (likee == null)
            {
                return NotFound();
            }

            return View(x);
        }

        // POST: Begeni/Duzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("LikeeID,UserrID,ClothID,LikeeDate")] Likee likee)
        {
            if (id != likee.LikeeID)
            {
                return NotFound();
            }

            LikeViewModel x = new LikeViewModel();
            x.Userrs = await _context.Userrs.ToListAsync();
            x.Clothes =await _context.Clothes.ToListAsync();
            x.Likee = likee;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(likee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LikeeExists(likee.LikeeID))
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

        // GET: Begeni/Sil/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null || _context.Likees == null)
            {
                return NotFound();
            }

            var likee = await _context.Likees
                .Include(l => l.Cloth)
                .Include(l => l.Userr)
                .FirstOrDefaultAsync(m => m.LikeeID == id);
            if (likee == null)
            {
                return NotFound();
            }

            return View(likee);
        }

        // POST: Begeni/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Likees == null)
            {
                return Problem("Entity set 'eserDbContext.Likees'  is null.");
            }
            var likee = await _context.Likees.FindAsync(id);
            if (likee != null)
            {
                _context.Likees.Remove(likee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listele));
        }

        private bool LikeeExists(int id)
        {
          return _context.Likees.Any(e => e.LikeeID == id);
        }
    }
}
