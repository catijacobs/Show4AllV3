using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Show4AllV3.Data;
using Show4AllV3.Models;

namespace Show4AllV3.Pages.UserViews
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Shows> Shows { get;set; }

        public async Task OnGetAsync()
        {
            Shows = await _context.Shows
                .Include(s => s.ActorList)
                .Include(s => s.Episode)
                .Include(s => s.Genre)
                .Include(s => s.Season).ToListAsync();
        }



    }
}
