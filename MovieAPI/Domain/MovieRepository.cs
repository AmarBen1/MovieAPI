using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Interfaces;

namespace MovieAPI.Domain
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies
                .Include(x => x.Actors)
                .Include(x => x.Director)
                .ToListAsync();
        }
    }
}
