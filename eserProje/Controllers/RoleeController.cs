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
    
    public class RoleeController : Controller
    {
        private readonly eserDbContext _context;

        public RoleeController(eserDbContext context)
        {
            _context = context;
        }

        // GET: Rolee
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rolees.ToListAsync());
        }

        // GET: Rolee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rolees == null)
            {
                return NotFound();
            }

            var rolee = await _context.Rolees
                .FirstOrDefaultAsync(m => m.RoleeID == id);
            if (rolee == null)
            {
                return NotFound();
            }

            return View(rolee);
        }

        // GET: Rolee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rolee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleeID,RoleeName")] Rolee rolee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolee);
        }

        // GET: Rolee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rolees == null)
            {
                return NotFound();
            }

            var rolee = await _context.Rolees.FindAsync(id);
            if (rolee == null)
            {
                return NotFound();
            }
            return View(rolee);
        }

        // POST: Rolee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleeID,RoleeName")] Rolee rolee)
        {
            if (id != rolee.RoleeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleeExists(rolee.RoleeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rolee);
        }

        // GET: Rolee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rolees == null)
            {
                return NotFound();
            }

            var rolee = await _context.Rolees
                .FirstOrDefaultAsync(m => m.RoleeID == id);
            if (rolee == null)
            {
                return NotFound();
            }

            return View(rolee);
        }

        // POST: Rolee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rolees == null)
            {
                return Problem("Entity set 'eserDbContext.Rolees'  is null.");
            }
            var rolee = await _context.Rolees.FindAsync(id);
            if (rolee != null)
            {
                _context.Rolees.Remove(rolee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleeExists(int id)
        {
          return _context.Rolees.Any(e => e.RoleeID == id);
        }
    }
}
