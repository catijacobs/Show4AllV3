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
    public class StarRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StarRatings
        public async Task<IActionResult> Index()
        {
            var show4AllV3Context = _context.StarRating.Include(s => s.Shows);
            return View(await show4AllV3Context.ToListAsync());
        }

        // GET: StarRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starRating = await _context.StarRating
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.RateId == id);
            if (starRating == null)
            {
                return NotFound();
            }

            return View(starRating);
        }

        // GET: StarRatings/Create
        public IActionResult Create()
        {
            ViewData["ShowsId"] = new SelectList(_context.Shows, "Id", "Id");
            return View();
        }

        // POST: StarRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RateId,Rate,Location,ShowsId")] StarRating starRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowsId"] = new SelectList(_context.Shows, "Id", "Id", starRating.ShowsId);
            return View(starRating);
        }

        // GET: StarRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starRating = await _context.StarRating.FindAsync(id);
            if (starRating == null)
            {
                return NotFound();
            }
            ViewData["ShowsId"] = new SelectList(_context.Shows, "Id", "Id", starRating.ShowsId);
            return View(starRating);
        }

        // POST: StarRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RateId,Rate,Location,ShowsId")] StarRating starRating)
        {
            if (id != starRating.RateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarRatingExists(starRating.RateId))
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
            ViewData["ShowsId"] = new SelectList(_context.Shows, "Id", "Id", starRating.ShowsId);
            return View(starRating);
        }

        // GET: StarRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starRating = await _context.StarRating
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.RateId == id);
            if (starRating == null)
            {
                return NotFound();
            }

            return View(starRating);
        }

        // POST: StarRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starRating = await _context.StarRating.FindAsync(id);
            _context.StarRating.Remove(starRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarRatingExists(int id)
        {
            return _context.StarRating.Any(e => e.RateId == id);
        }
    }
}
