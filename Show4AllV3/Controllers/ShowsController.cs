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
    public class ShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowsController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var show4AllV3Context = _context.Shows.Include(s => s.ActorList).Include(s => s.Episode).Include(s => s.Season).Include(s => s.Genre);
            return View(await show4AllV3Context.ToListAsync());
        }



        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows
                .Include(s => s.ActorList)
                .Include(s => s.Episode)
                .Include(s => s.Season)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shows == null)
            {
                return NotFound();
            }

            return View(shows);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {

            ViewData["ActorListId"] = new SelectList(_context.Set<ActorList>(), "Id", "Name");
            ViewData["EpisodeId"] = new SelectList(_context.Set<Episode>(), "Id", "Name");
            ViewData["SeasonId"] = new SelectList(_context.Set<Season>(), "Id", "Name");
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Year,Image,Price,IsAvailable,ActorListId,SeasonId,EpisodeId,GenreId")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shows);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorListId"] = new SelectList(_context.Set<ActorList>(), "Id", "Name", shows.ActorListId);
            ViewData["EpisodeId"] = new SelectList(_context.Set<Episode>(), "Id", "Name", shows.EpisodeId);
            ViewData["SeasonId"] = new SelectList(_context.Set<Season>(), "Id", "Name", shows.SeasonId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", shows.GenreId);
            return View(shows);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows.FindAsync(id);
            if (shows == null)
            {
                return NotFound();
            }
            ViewData["ActorListId"] = new SelectList(_context.Set<ActorList>(), "Id", "Name", shows.ActorListId);
            ViewData["EpisodeId"] = new SelectList(_context.Set<Episode>(), "Id", "Name", shows.EpisodeId);
            ViewData["SeasonId"] = new SelectList(_context.Set<Season>(), "Id", "Name", shows.SeasonId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", shows.GenreId);
            return View(shows);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Year,Image,Price,IsAvailable,ActorListId,SeasonId,EpisodeId,GenreId")] Shows shows)
        {
            if (id != shows.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shows);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowsExists(shows.Id))
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
            ViewData["ActorListId"] = new SelectList(_context.Set<ActorList>(), "Id", "Name", shows.ActorListId);
            ViewData["EpisodeId"] = new SelectList(_context.Set<Episode>(), "Id", "Name", shows.EpisodeId);
            ViewData["SeasonId"] = new SelectList(_context.Set<Season>(), "Id", "Name", shows.SeasonId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", shows.GenreId);
            return View(shows);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows
                .Include(s => s.ActorList)
                .Include(s => s.Episode)
                .Include(s => s.Season)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shows == null)
            {
                return NotFound();
            }

            return View(shows);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shows = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(shows);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowsExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
