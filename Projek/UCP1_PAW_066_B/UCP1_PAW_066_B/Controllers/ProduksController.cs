﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_066_B.Models;

namespace UCP1_PAW_066_B.Controllers
{
    public class ProduksController : Controller
    {
        private readonly PenjualanContext _context;

        public ProduksController(PenjualanContext context)
        {
            _context = context;
        }

        // GET: Produks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produks.ToListAsync());
        }

        // GET: Produks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produks
                .FirstOrDefaultAsync(m => m.IdProduk == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // GET: Produks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduk,NamaProduk,Quantity")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produk);
        }

        // GET: Produks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produks.FindAsync(id);
            if (produk == null)
            {
                return NotFound();
            }
            return View(produk);
        }

        // POST: Produks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduk,NamaProduk,Quantity")] Produk produk)
        {
            if (id != produk.IdProduk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukExists(produk.IdProduk))
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
            return View(produk);
        }

        // GET: Produks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produks
                .FirstOrDefaultAsync(m => m.IdProduk == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // POST: Produks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produk = await _context.Produks.FindAsync(id);
            _context.Produks.Remove(produk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukExists(int id)
        {
            return _context.Produks.Any(e => e.IdProduk == id);
        }
    }
}
