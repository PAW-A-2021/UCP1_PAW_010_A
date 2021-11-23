using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_010_A.Models;

namespace UCP1_PAW_010_A.Controllers
{
    public class GajisController : Controller
    {
        private readonly pergajianContext _context;

        public GajisController(pergajianContext context)
        {
            _context = context;
        }

        // GET: Gajis
        public async Task<IActionResult> Index()
        {
            var pergajianContext = _context.Gajis.Include(g => g.IdkaryawanNavigation);
            return View(await pergajianContext.ToListAsync());
        }

        // GET: Gajis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaji = await _context.Gajis
                .Include(g => g.IdkaryawanNavigation)
                .FirstOrDefaultAsync(m => m.Idgaji == id);
            if (gaji == null)
            {
                return NotFound();
            }

            return View(gaji);
        }

        // GET: Gajis/Create
        public IActionResult Create()
        {
            ViewData["Idkaryawan"] = new SelectList(_context.Karyawans, "Idkaryawan", "Idkaryawan");
            return View();
        }

        // POST: Gajis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idgaji,NoSlip,Tanggal,GajiBulan,Idkaryawan,Lembur,Masuk,SubTotal,Pph,Total")] Gaji gaji)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gaji);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idkaryawan"] = new SelectList(_context.Karyawans, "Idkaryawan", "Idkaryawan", gaji.Idkaryawan);
            return View(gaji);
        }

        // GET: Gajis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaji = await _context.Gajis.FindAsync(id);
            if (gaji == null)
            {
                return NotFound();
            }
            ViewData["Idkaryawan"] = new SelectList(_context.Karyawans, "Idkaryawan", "Idkaryawan", gaji.Idkaryawan);
            return View(gaji);
        }

        // POST: Gajis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idgaji,NoSlip,Tanggal,GajiBulan,Idkaryawan,Lembur,Masuk,SubTotal,Pph,Total")] Gaji gaji)
        {
            if (id != gaji.Idgaji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gaji);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GajiExists(gaji.Idgaji))
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
            ViewData["Idkaryawan"] = new SelectList(_context.Karyawans, "Idkaryawan", "Idkaryawan", gaji.Idkaryawan);
            return View(gaji);
        }

        // GET: Gajis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaji = await _context.Gajis
                .Include(g => g.IdkaryawanNavigation)
                .FirstOrDefaultAsync(m => m.Idgaji == id);
            if (gaji == null)
            {
                return NotFound();
            }

            return View(gaji);
        }

        // POST: Gajis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gaji = await _context.Gajis.FindAsync(id);
            _context.Gajis.Remove(gaji);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GajiExists(int id)
        {
            return _context.Gajis.Any(e => e.Idgaji == id);
        }
    }
}
