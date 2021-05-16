using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Show4AllV3.Data;
using Show4AllV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show4AllV3.Repositories
{
    public class StarRatingRepository
    {
        private readonly ApplicationDbContext _ctx;

        public object StarRating1 { get; internal set; }
        public object Shows { get; internal set; }

        public StarRatingRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<StarRating1> GetAsync(int id)
        {
            return await _ctx.StarRating1.FindAsync(id);
        }

        public StarRating1 Add(string name)
        {
            var starrating1 = new StarRating1 { Name = name };

            _ctx.StarRating1.Add(starrating1);
            _ctx.SaveChanges();

            return starrating1;
        }

        public async Task<StarRating1> AddAsync(StarRating1 rating)
        {
            _ctx.StarRating1.Add(rating);

            await _ctx.SaveChangesAsync();

            return rating;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var starrating1 = _ctx.StarRating1.FirstOrDefault(u => u.Id == id);

            if (starrating1 == null)
                return false;

            _ctx.Remove(starrating1);
            await _ctx.SaveChangesAsync();

            return true;
        }

     


    }
}
