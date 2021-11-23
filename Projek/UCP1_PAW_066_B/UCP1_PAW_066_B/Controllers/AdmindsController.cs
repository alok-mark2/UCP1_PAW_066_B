using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_066_B.Models;

namespace UCP1_PAW_066_B.Controllers
{
    public class AdmindsController : Controller
    {
        private readonly PenjualanContext _context;

        public AdmindsController(PenjualanContext context)
        {
            _context = context;
        }

        // GET: Adminds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adminds.ToListAsync());
        }

        // GET: Adminds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admind = await _context.Adminds
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (admind == null)
            {
                return NotFound();
            }

            return View(admind);
        }

        // GET: Adminds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adminds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdmin,NamaAdmin")] Admind admind)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admind);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admind);
        }

        // GET: Adminds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admind = await _context.Adminds.FindAsync(id);
            if (admind == null)
            {
                return NotFound();
            }
            return View(admind);
        }

        // POST: Adminds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdmin,NamaAdmin")] Admind admind)
        {
            if (id != admind.IdAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admind);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmindExists(admind.IdAdmin))
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
            return View(admind);
        }

        // GET: Adminds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admind = await _context.Adminds
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (admind == null)
            {
                return NotFound();
            }

            return View(admind);
        }

        // POST: Adminds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admind = await _context.Adminds.FindAsync(id);
            _context.Adminds.Remove(admind);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmindExists(int id)
        {
            return _context.Adminds.Any(e => e.IdAdmin == id);
        }
    }
}
