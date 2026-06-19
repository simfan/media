using Medias.Data.Contexts;
using Medias.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medias.Server.Repositories
{
    public class MovieDetailRepository
    {
        private readonly MediaDbContext _context;

        public MovieDetailRepository(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDetail>>GetMovieDetails()
        {
            var movieDetails = await _context.MovieDetails.ToListAsync();
            return movieDetails;
        }

        public async Task<MovieDetail> AddMovieDetail(MovieDetail movieDetail)
        {
            await _context.MovieDetails.AddAsync(movieDetail);
            _context.SaveChanges();
            return movieDetail;
        }

        public async Task<bool> UpdateMovieDetail(MovieDetail movieDetail)
        {
            var existingMovie = await _context.MovieDetails.FindAsync(movieDetail.MediaItemId);
            if (existingMovie is null)
            {
                throw new InvalidOperationException("Movie Detail not found");
            }
            _context.Entry(existingMovie).CurrentValues.SetValues(movieDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
