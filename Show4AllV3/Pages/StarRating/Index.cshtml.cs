using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Show4AllV3.Data;
using Show4AllV3.Models;

namespace Show4AllV3.Pages.StarRating
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StarRating1> StarRating1 { get;set; }

        public async Task OnGetAsync()
        {
            StarRating1 = await _context.StarRating1.ToListAsync();
        }
    }
}
