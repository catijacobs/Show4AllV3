using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Show4AllV3.Models;

namespace Show4AllV3.Pages.StarRating
{
    public class CreateModel : PageModel
    {
        private readonly Show4AllV3Context _context;

        public CreateModel(Show4AllV3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StarRating1 StarRating1 { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StarRating1.Add(StarRating1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
