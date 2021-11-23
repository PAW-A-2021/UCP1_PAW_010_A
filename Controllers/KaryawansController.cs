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
    public class KaryawansController : Controller
    {
        private readonly pergajianContext _context;

        public KaryawansController(pergajianContext context)
        {
            _context = context;
        }

        // GET: Karyawans
        public async Task<IActionResult> Index()
        {
            var pergajianContext = _context.Karyawans.Include(k => k.IdgolonganNavigation).Include(k => k.IdjabatanNavigation);
            return View(await pergajianContext.ToListAsync());
        }

        // GET: Karyawans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karyawan = await _context.Karyawans
                .Include(k => k.IdgolonganNavigation)
                .Include(k => k.IdjabatanNavigation)
                .FirstOrDefaultAsync(m => m.Idkaryawan == id);
            if (karyawan == null)
            {
                return NotFound();
            }

            return View(karyawan);
        }

        // GET: Karyawans/Create
        public IActionResult Create()
        {
            ViewData["Idgolongan"] = new SelectList(_context.Golongans, "Idgolongan", "Idgolongan");
            ViewData["Idjabatan"] = new SelectList(_context.Jabatans, "Idjabatan", "Jabatan1");
            return View();
        }

        // POST: Karyawans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idkaryawan,Nip,Nama,JenisKelamin,Alamat,Idjabatan,Idgolongan,Status")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karyawan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idgolongan"] = new SelectList(_context.Golongans, "Idgolongan", "Idgolongan", karyawan.Idgolongan);
            ViewData["Idjabatan"] = new SelectList(_context.Jabatans, "Idjabatan", "Jabatan1", karyawan.Idjabatan);
            return View(karyawan);
        }

        // GET: Karyawans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karyawan = await _context.Karyawans.FindAsync(id);
            if (karyawan == null)
            {
                return NotFound();
            }
            ViewData["Idgolongan"] = new SelectList(_context.Golongans, "Idgolongan", "Idgolongan", karyawan.Idgolongan);
            ViewData["Idjabatan"] = new SelectList(_context.Jabatans, "Idjabatan", "Jabatan1", karyawan.Idjabatan);
            return View(karyawan);
        }

        // POST: Karyawans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idkaryawan,Nip,Nama,JenisKelamin,Alamat,Idjabatan,Idgolongan,Status")] Karyawan karyawan)
        {
            if (id != karyawan.Idkaryawan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karyawan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KaryawanExists(karyawan.Idkaryawan))
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
            ViewData["Idgolongan"] = new SelectList(_context.Golongans, "Idgolongan", "Idgolongan", karyawan.Idgolongan);
            ViewData["Idjabatan"] = new SelectList(_context.Jabatans, "Idjabatan", "Jabatan1", karyawan.Idjabatan);
            return View(karyawan);
        }

        // GET: Karyawans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karyawan = await _context.Karyawans
                .Include(k => k.IdgolonganNavigation)
                .Include(k => k.IdjabatanNavigation)
                .FirstOrDefaultAsync(m => m.Idkaryawan == id);
            if (karyawan == null)
            {
                return NotFound();
            }

            return View(karyawan);
        }

        // POST: Karyawans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karyawan = await _context.Karyawans.FindAsync(id);
            _context.Karyawans.Remove(karyawan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KaryawanExists(int id)
        {
            return _context.Karyawans.Any(e => e.Idkaryawan == id);
        }
    }
}
