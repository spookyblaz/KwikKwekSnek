using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using KwikKwekSnek.Models;

namespace k.Controllers
{
    public class DrankjesController : Controller
    {
        private readonly MyContext _context;

        public DrankjesController(MyContext context)
        {
            _context = context;
        }

        // GET: Drankjes
        public async Task<IActionResult> Index()
        {
            return View(await _context.drankjes.ToListAsync());
        }

        // GET: Persoons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankje = await _context.drankjes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (drankje == null)
            {
                return NotFound();
            }

            return View(drankje);
        }

        // GET: Drankjes/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Persoons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam, Description, afbeelding, prijs, grootte, ijs, plasticrietje,ID")] Drankje drankje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drankje);
                await _context.SaveChangesAsync();
                return RedirectToAction("index", "drankjes");
            }
            return View(drankje);
        }





        // GET: Persoons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankje = await _context.drankjes.FindAsync(id);
            if (drankje == null)
            {
                return NotFound();
            }
            return View(drankje);
        }

        // POST: Persoons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personalNumber,naam,phoneNumber,email")] Drankje drankje)
        {
            if (id != drankje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drankje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrankjeExists(drankje.ID))
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
            return View(drankje);
        }

        // GET: Persoons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankje = await _context.drankjes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (drankje == null)
            {
                return NotFound();
            }

            return View(drankje);
        }

        // POST: Persoons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drankje = await _context.drankjes.FindAsync(id);
            _context.drankjes.Remove(drankje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrankjeExists(int id)
        {
            return _context.drankjes.Any(e => e.ID == id);
        }
    }
}
