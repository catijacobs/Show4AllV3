using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Show4AllV3.Areas.Data;
using Show4AllV3.Data;

[assembly: HostingStartup(typeof(Show4AllV3.Areas.Identity.IdentityHostingStartup))]

namespace Show4AllV3.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));
                services.AddIdentity<SampleAppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
                services.AddScoped<IUserClaimsPrincipalFactory<SampleAppUser>,
                    ApplicationUserClaimsPrincipalFactory
                    >();
            });
        }


    }

}
