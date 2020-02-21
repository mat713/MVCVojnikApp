using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcVojnik.Data;
using MvcVojnik.Models;

namespace MvcVojnik.Controllers
{
    public class VojniciController : Controller
    {
        private readonly MvcVojnikContext _context;

        public VojniciController(MvcVojnikContext context)
        {
            _context = context;
        }

        // GET: Vojnici
        public async Task<IActionResult> Index(string searchString)
        {
            var vojnici = from v in _context.Vojnik select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vojnici = vojnici.Where(s => s.Ime.Contains(searchString));
            }
            return View(await vojnici.ToListAsync());
        }

        // GET: Vojnici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vojnik = await _context.Vojnik
                .FirstOrDefaultAsync(m => m.VojnikId == id);
            if (vojnik == null)
            {
                return NotFound();
            }

            return View(vojnik);
        }

        // GET: Vojnici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vojnici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VojnikId,Ime,Prezime,DatumRođenja,Baza,Pozicija")] Vojnik vojnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vojnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vojnik);
        }

        // GET: Vojnici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vojnik = await _context.Vojnik.FindAsync(id);
            if (vojnik == null)
            {
                return NotFound();
            }
            return View(vojnik);
        }

        // POST: Vojnici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VojnikId,Ime,Prezime,DatumRođenja,Baza,Pozicija")] Vojnik vojnik)
        {
            if (id != vojnik.VojnikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vojnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VojnikExists(vojnik.VojnikId))
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
            return View(vojnik);
        }

        // GET: Vojnici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vojnik = await _context.Vojnik
                .FirstOrDefaultAsync(m => m.VojnikId == id);
            if (vojnik == null)
            {
                return NotFound();
            }

            return View(vojnik);
        }

        // POST: Vojnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vojnik = await _context.Vojnik.FindAsync(id);
            _context.Vojnik.Remove(vojnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VojnikExists(int id)
        {
            return _context.Vojnik.Any(e => e.VojnikId == id);
        }
    }
}
