using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Show4AllV3.Models;
using Microsoft.AspNetCore.Identity;
using Show4AllV3.Areas.Data;

namespace Show4AllV3.Data
{
    public class ApplicationDbContext : IdentityDbContext<SampleAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Show4AllV3.Models.Shows> Shows { get; set; }
        public DbSet<Show4AllV3.Models.ActorList> ActorList { get; set; }
        public DbSet<Show4AllV3.Models.Season> Season { get; set; }
        public DbSet<Show4AllV3.Models.Episode> Episode { get; set; }
        public DbSet<Show4AllV3.Models.StarRating> StarRating { get; set; }
    }



}


