using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show4AllV3.Areas.Data
{
    public class SampleAppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
