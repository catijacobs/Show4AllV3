using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Show4AllV3.Data;
using Show4AllV3.Models;

namespace Show4AllV3.Controllers
{
    public class ActorListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActorLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActorList.ToListAsync());
        }

        // GET: ActorLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorList = await _context.ActorList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorList == null)
            {
                return NotFound();
            }

            return View(actorList);
        }
        [Authorize(Policy = "rolecreation")]
        public IActionResult Create()
        {
            return View();
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image")] ActorList actorList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actorList);
        }

        [Authorize(Policy = "rolecreation")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorList = await _context.ActorList.FindAsync(id);
            if (actorList == null)
            {
                return NotFound();
            }
            return View(actorList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image")] ActorList actorList)
        {
            if (id != actorList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorListExists(actorList.Id))
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
            return View(actorList);
        }

        // GET: ActorLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorList = await _context.ActorList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorList == null)
            {
                return NotFound();
            }

            return View(actorList);
        }

        // POST: ActorLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorList = await _context.ActorList.FindAsync(id);
            _context.ActorList.Remove(actorList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorListExists(int id)
        {
            return _context.ActorList.Any(e => e.Id == id);
        }
    }
}
