using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Show4AllV3.Areas;
using Show4AllV3.Areas.Data;
using Show4AllV3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show4AllV3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


       services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(
       Configuration.GetConnectionString("DefaultConnection")));


        services.AddDatabaseDeveloperPageExceptionFilter();



             services.AddAuthorization(options =>
             {
                 options.FallbackPolicy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                      .Build();

                 options.AddPolicy("EmailID", policy =>
                policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
                ));

                 options.AddPolicy("rolecreation", policy =>
                 policy.RequireRole("Admin")
                 );



             });



        } 


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
