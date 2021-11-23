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
    public class GolongansController : Controller
    {
        private readonly pergajianContext _context;

        public GolongansController(pergajianContext context)
        {
            _context = context;
        }

        // GET: Golongans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Golongans.ToListAsync());
        }

        // GET: Golongans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var golongan = await _context.Golongans
                .FirstOrDefaultAsync(m => m.Idgolongan == id);
            if (golongan == null)
            {
                return NotFound();
            }

            return View(golongan);
        }

        // GET: Golongans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Golongans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idgolongan,Golongan1,TjKeluarga,TjKesehatan,UangLembur,UangMakan")] Golongan golongan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(golongan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(golongan);
        }

        // GET: Golongans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var golongan = await _context.Golongans.FindAsync(id);
            if (golongan == null)
            {
                return NotFound();
            }
            return View(golongan);
        }

        // POST: Golongans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idgolongan,Golongan1,TjKeluarga,TjKesehatan,UangLembur,UangMakan")] Golongan golongan)
        {
            if (id != golongan.Idgolongan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(golongan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GolonganExists(golongan.Idgolongan))
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
            return View(golongan);
        }

        // GET: Golongans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var golongan = await _context.Golongans
                .FirstOrDefaultAsync(m => m.Idgolongan == id);
            if (golongan == null)
            {
                return NotFound();
            }

            return View(golongan);
        }

        // POST: Golongans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var golongan = await _context.Golongans.FindAsync(id);
            _context.Golongans.Remove(golongan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GolonganExists(int id)
        {
            return _context.Golongans.Any(e => e.Idgolongan == id);
        }
    }
}
