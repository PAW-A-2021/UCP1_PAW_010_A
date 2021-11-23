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
    public class JabatansController : Controller
    {
        private readonly pergajianContext _context;

        public JabatansController(pergajianContext context)
        {
            _context = context;
        }

        // GET: Jabatans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jabatans.ToListAsync());
        }

        // GET: Jabatans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jabatan = await _context.Jabatans
                .FirstOrDefaultAsync(m => m.Idjabatan == id);
            if (jabatan == null)
            {
                return NotFound();
            }

            return View(jabatan);
        }

        // GET: Jabatans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jabatans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idjabatan,Jabatan1,Gajipokok,TjJabatan")] Jabatan jabatan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jabatan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jabatan);
        }

        // GET: Jabatans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jabatan = await _context.Jabatans.FindAsync(id);
            if (jabatan == null)
            {
                return NotFound();
            }
            return View(jabatan);
        }

        // POST: Jabatans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idjabatan,Jabatan1,Gajipokok,TjJabatan")] Jabatan jabatan)
        {
            if (id != jabatan.Idjabatan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jabatan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JabatanExists(jabatan.Idjabatan))
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
            return View(jabatan);
        }

        // GET: Jabatans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jabatan = await _context.Jabatans
                .FirstOrDefaultAsync(m => m.Idjabatan == id);
            if (jabatan == null)
            {
                return NotFound();
            }

            return View(jabatan);
        }

        // POST: Jabatans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jabatan = await _context.Jabatans.FindAsync(id);
            _context.Jabatans.Remove(jabatan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JabatanExists(int id)
        {
            return _context.Jabatans.Any(e => e.Idjabatan == id);
        }
    }
}
