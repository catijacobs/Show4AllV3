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
    public class ActorModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ActorModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ActorList> ActorList { get;set; }

        public async Task OnGetAsync()
        {
            ActorList = await _context.ActorList.ToListAsync();
        }
    }
}
