using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Show4AllV3.Data;
using Show4AllV3.Models;
using Show4AllV3.Repositories;

namespace Show4AllV3.Pages.StarRating
{
    public class CreateModel : PageModel
    {
        private readonly StarRatingRepository _starratingrepository;

        public CreateModel(StarRatingRepository starratingrepository)
        {
            
            _starratingrepository = starratingrepository;
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

            var rating = await _starratingrepository.AddAsync(StarRating1);


            return RedirectToPage("./Index");
        }
    }
}
