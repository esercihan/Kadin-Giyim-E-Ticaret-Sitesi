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
   
    public class UserrController : Controller
    {
        private readonly eserDbContext _context;

        public UserrController(eserDbContext context)
        {
            _context = context;
        }

        // GET: Userr
        public async Task<IActionResult> Index()
        {
            var eserDbContext = _context.Userrs.Include(u => u.Rolee);
            return View(await eserDbContext.ToListAsync());
        }

        // GET: Userr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Userrs == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs
                .Include(u => u.Rolee)
                .FirstOrDefaultAsync(m => m.UserrID == id);
            if (userr == null)
            {
                return NotFound();
            }

            return View(userr);
        }

        // GET: Userr/Create
        public IActionResult Create()
        {
            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName");
            return View();
        }

        // POST: Userr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserrID,Email,Password,RoleeID")] Userr userr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName", userr.RoleeID);
            return View(userr);
        }

        // GET: Userr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userrs == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs.FindAsync(id);
            if (userr == null)
            {
                return NotFound();
            }
            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName", userr.RoleeID);
            return View(userr);
        }

        // POST: Userr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserrID,Email,Password,RoleeID")] Userr userr)
        {
            if (id != userr.UserrID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserrExists(userr.UserrID))
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
            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName", userr.RoleeID);
            return View(userr);
        }

        // GET: Userr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userrs == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs
                .Include(u => u.Rolee)
                .FirstOrDefaultAsync(m => m.UserrID == id);
            if (userr == null)
            {
                return NotFound();
            }

            return View(userr);
        }

        // POST: Userr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userrs == null)
            {
                return Problem("Entity set 'eserDbContext.Userrs'  is null.");
            }
            var userr = await _context.Userrs.FindAsync(id);
            if (userr != null)
            {
                _context.Userrs.Remove(userr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserrExists(int id)
        {
          return _context.Userrs.Any(e => e.UserrID == id);
        }
    }
}
