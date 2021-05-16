using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Show4AllV3.Data;
using Show4AllV3.Models;

namespace Show4AllV3.Controllers
{
    public class StarRating1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarRating1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StarRating1
        public async Task<IActionResult> Index()
        {
            return View(await _context.StarRating1.ToListAsync());
        }

        // GET: StarRating1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starRating1 = await _context.StarRating1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starRating1 == null)
            {
                return NotFound();
            }

            return View(starRating1);
        }

        // GET: StarRating1/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StarRating1 starRating1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starRating1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starRating1);
        }

        // GET: StarRating1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starRating1 = await _context.StarRating1.FindAsync(id);
            if (starRating1 == null)
            {
                return NotFound();
            }
            return View(starRating1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StarRating1 starRating1)
        {
            if (id != starRating1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starRating1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarRating1Exists(starRating1.Id))
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
            return View(starRating1);
        }

        // GET: StarRating1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starRating1 = await _context.StarRating1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starRating1 == null)
            {
                return NotFound();
            }

            return View(starRating1);
        }

        // POST: StarRating1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starRating1 = await _context.StarRating1.FindAsync(id);
            _context.StarRating1.Remove(starRating1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarRating1Exists(int id)
        {
            return _context.StarRating1.Any(e => e.Id == id);
        }
    }
}
