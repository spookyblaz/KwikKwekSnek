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
    public class BestellingsController : Controller
    {
        private readonly MyContext _context;


        private readonly IWebHostEnvironment _hostEnvironment;

        public BestellingsController(MyContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;

            _hostEnvironment = HostEnvironment;
        }

        // GET: Drankjes
        public async Task<IActionResult> Create() // begint bestelling
        {
            Bestelling bestelling = new Bestelling();
            _context.Add(bestelling);
            await _context.SaveChangesAsync();
            ViewBag.bestellingsnummer = bestelling.bestellingsnummer;

            return View();
        }

        public async Task<IActionResult> besteldrankjes(int? id, int bestellingsnummer) // regelt view drankjes bestellen
        {
            ViewBag.bestellingsnummer = bestellingsnummer;
            ViewBag.id = id;
            return View(await _context.drankjes.ToListAsync());
        }


        // GET: Persoons/Details/5
        public async Task<IActionResult> Bestelextrasdrankjes(int? id, int bestellingsnummer)
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
            // IEnumerable<Drankje> drankjes = (IEnumerable<Drankje>)drankje;
            ViewBag.id = drankje.ID;
            ViewBag.bestellingsnummer = bestellingsnummer;
            ViewBag.prijs = drankje.prijs;

            return View();
        }

        

        // POST: Persoons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> bestelextrasdrankje(int? iddrankje, int? bestellingsnummer, [Bind(" grootte, ijs, plasticrietje")] Extrasdrankje extrasdrankje
                      // ,[Bind(" drankje , extrasdrankje, ")] Drankjehasextra drankjehasextra , Bestelling bestelling
            )
        {
            if (ModelState.IsValid)
            {
                if (iddrankje == null)
                {

                }
           //     drankjehasextra.Drankje = await _context.drankjes.FirstOrDefaultAsync(m => m.ID == iddrankje);
           //     drankjehasextra.Extrasdrankje = extrasdrankje;

              


           }

              _context.Add(extrasdrankje);
            //    _context.Add(drankjehasextra);

           // var Eric = _context.Bestelling.Where(p => p.bestellingsnummer == bestellingsnummer).Include(p => p.besteldedrankjes).FirstOrDefault();
           // var captuurtje = _context..Where(c => c.ID == iddrankje).FirstOrDefault();
            //   if (Eric != null && captuurtje != null)
            //     {
            //       Console.WriteLine(Eric.bestellingsnummer);
            //       Console.Write(captuurtje.ID);
            //     Eric.besteldedrankjes.Add(captuurtje);
            //       bestelling.bestellingsnummer = 
            //   bestelling.besteldedrankjes.Add(drankjehasextra);
            await _context.SaveChangesAsync();
                return RedirectToAction("besteldrankjes", new { bestellingsnummer = bestellingsnummer });
            }
         





    }
}
