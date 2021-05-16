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
        public StarRatingRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
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
    }
}
