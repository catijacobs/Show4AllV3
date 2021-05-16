using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Show4AllV3.Data;
using Show4AllV3.Models;
using Show4AllV3.Repositories;

namespace Show4AllV3.Pages.StarRating
{
    public class DeleteModel : PageModel
    {
        private readonly StarRatingRepository _starratingrepository;

        public DeleteModel(StarRatingRepository starratingrepository)
        {
            _starratingrepository = starratingrepository;
        }

        [BindProperty]
        public StarRating1 StarRating1 { get; set; }
        public StarRatingRepository Starratingrepository { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StarRating1 = await _starratingrepository.GetAsync(id.Value);

            if (StarRating1 == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            _ = await _starratingrepository.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
