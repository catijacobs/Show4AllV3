using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show4AllV3.Controllers
{
    public class ActorListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
