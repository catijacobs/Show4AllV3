using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Show4AllV3.Areas.Data
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<SampleAppUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<SampleAppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options
            ) : base(userManager, roleManager, options)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(SampleAppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FullName",
                user.FullName
                ));
            return identity;
        }
    }
}
