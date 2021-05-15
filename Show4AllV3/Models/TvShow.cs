using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Show4AllV3.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public TvShow()
        {

        }

        
    }
}
