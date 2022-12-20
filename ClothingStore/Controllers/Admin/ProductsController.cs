using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Data;
using ClothingStore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ClothingStore.Controllers.Home
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.Sex).Include(p => p.Size).Include(p => p.Textile).Include(p => p.Vendor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Sex)
                .Include(p => p.Size)
                .Include(p => p.Textile)
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "Name");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name");
            ViewData["TextileId"] = new SelectList(_context.Set<Textile>(), "Id", "Name");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Img, [Bind("Id,Name,Price,ColorId,CategoryId,SizeId,SexId,VendorId,Quantity,Img,TextileId")] Product product)
        {
            if (Img != null)
            {
                string urlPath = "/store/images/";

                string diskPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot" + urlPath));
                if (!Directory.Exists(diskPath))
                {
                    Directory.CreateDirectory(diskPath);
                }

                using (var fileStream = new FileStream(Path.Combine(diskPath, Img.FileName), FileMode.Create))
                {
                    await Img.CopyToAsync(fileStream);
                }

                product.Img = urlPath + Img.FileName;

            }
            else
            {
                return View(product);
            }

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "Name", product.SexId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name", product.SizeId);
            ViewData["TextileId"] = new SelectList(_context.Set<Textile>(), "Id", "Name", product.TextileId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", product.VendorId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "Name", product.SexId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name", product.SizeId);
            ViewData["TextileId"] = new SelectList(_context.Set<Textile>(), "Id", "Name", product.TextileId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", product.VendorId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,ColorId,CategoryId,SizeId,SexId,VendorId,Quantity,Img,TextileId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "Name", product.SexId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Name", product.SizeId);
            ViewData["TextileId"] = new SelectList(_context.Set<Textile>(), "Id", "Name", product.TextileId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", product.VendorId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Sex)
                .Include(p => p.Size)
                .Include(p => p.Textile)
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
