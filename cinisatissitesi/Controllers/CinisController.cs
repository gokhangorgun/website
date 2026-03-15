using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cinisatissitesi.Data;
using cinisatissitesi.Models;

namespace cinisatissitesi.Controllers
{
    public class CinisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinisController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUser"));
        }

        // GET: Cinis
        public async Task<IActionResult> Index()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            return View(await _context.Ciniler.ToListAsync());
        }

        // GET: Cinis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id == null)
            {
                return NotFound();
            }

            var cini = await _context.Ciniler.FirstOrDefaultAsync(m => m.Id == id);

            if (cini == null)
            {
                return NotFound();
            }

            return View(cini);
        }

        // GET: Cinis/Create
        public IActionResult Create()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // POST: Cinis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,Stok,ResimUrl,Kategori")] Cini cini)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Ciniler.Add(cini);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cini);
        }

        // GET: Cinis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id == null)
            {
                return NotFound();
            }

            var cini = await _context.Ciniler.FindAsync(id);
            if (cini == null)
            {
                return NotFound();
            }

            return View(cini);
        }

        // POST: Cinis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Fiyat,Stok,ResimUrl,Kategori")] Cini cini)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id != cini.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ciniler.Update(cini);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiniExists(cini.Id))
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

            return View(cini);
        }

        // GET: Cinis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id == null)
            {
                return NotFound();
            }

            var cini = await _context.Ciniler.FirstOrDefaultAsync(m => m.Id == id);
            if (cini == null)
            {
                return NotFound();
            }

            return View(cini);
        }

        // POST: Cinis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            var cini = await _context.Ciniler.FindAsync(id);
            if (cini != null)
            {
                _context.Ciniler.Remove(cini);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CiniExists(int id)
        {
            return _context.Ciniler.Any(e => e.Id == id);
        }
    }
}