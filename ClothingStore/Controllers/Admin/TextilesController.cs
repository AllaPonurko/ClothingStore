using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Data;
using ClothingStore.Models;

namespace ClothingStore.Controllers.Home
{
    public class TextilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TextilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Textiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Textile.ToListAsync());
        }

        // GET: Textiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var textile = await _context.Textile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textile == null)
            {
                return NotFound();
            }

            return View(textile);
        }

        // GET: Textiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Textiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Textile textile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(textile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(textile);
        }

        // GET: Textiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var textile = await _context.Textile.FindAsync(id);
            if (textile == null)
            {
                return NotFound();
            }
            return View(textile);
        }

        // POST: Textiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Textile textile)
        {
            if (id != textile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(textile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextileExists(textile.Id))
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
            return View(textile);
        }

        // GET: Textiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var textile = await _context.Textile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textile == null)
            {
                return NotFound();
            }

            return View(textile);
        }

        // POST: Textiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var textile = await _context.Textile.FindAsync(id);
            _context.Textile.Remove(textile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextileExists(int id)
        {
            return _context.Textile.Any(e => e.Id == id);
        }
    }
}
