using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using KwikKwekSnek.Models;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace k.Controllers
{
    public class DrankjesController : Controller
    {
        private readonly MyContext _context;


        private readonly IWebHostEnvironment _hostEnvironment;

        public DrankjesController(MyContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;

            _hostEnvironment = HostEnvironment;
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
        public async Task<IActionResult> Create(IFormFile foto,[Bind("Naam, Description, afbeelding, drankImageUrl, prijs, grootte, ijs, plasticrietje, ID")] Drankje drankje)
        {
            if (ModelState.IsValid)
            {
                
                //if (drankje.drankImageUrl != null)

                if (foto != null)

                {
                    string wwwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(foto.FileName);
                    string extension = Path.GetExtension(foto.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmddssfff") + extension;
                    string path = Path.Combine(wwwwRootPath + "/image", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await foto.CopyToAsync(fileStream);
                    }
                    drankje.afbeelding = fileName;
                    
                }

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
        public async Task<IActionResult> Edit(int id, IFormFile foto, [Bind("Naam, Description, afbeelding, drankImageUrl, prijs, grootte, ijs, plasticrietje,ID")] Drankje drankje)
        {
            if (id != drankje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (foto != null)

                    {
                        string wwwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(foto.FileName);
                        string extension = Path.GetExtension(foto.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmddssfff") + extension;
                        string path = Path.Combine(wwwwRootPath + "/image", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await foto.CopyToAsync(fileStream);
                        }
                        drankje.afbeelding = fileName;

                    }
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
