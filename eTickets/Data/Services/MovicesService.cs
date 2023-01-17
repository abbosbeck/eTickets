﻿using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eTickets.Data.Services
{
    public class MovicesService : EntityBaseRepository<Movie>, IMoviesSerivce
    {
        private readonly AppDbContext _context;
        public MovicesService(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies.
                Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
                
        }

        public Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            throw new NotImplementedException();
        }
    }
}
