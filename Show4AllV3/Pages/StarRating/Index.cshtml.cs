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
    public class IndexModel : PageModel
    {
        private readonly StarRatingRepository _starratingrepository;

        public IndexModel(StarRatingRepository starratingrepository)
        {

            _starratingrepository = starratingrepository;
        }


        public IList<StarRating1> StarRating1 { get;set; }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
