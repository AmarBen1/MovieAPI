using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.DTOs;
using MovieAPI.Extensions;
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


        public Movie AddMovie(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }

        public int GetExistingActor(Actor actor)
        {
            var existingActor = _context.Actors
                .Where(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName)
                .AsNoTracking() // No tracking of the entity
                .FirstOrDefault();
            if (existingActor != null)
            {
                return existingActor.Id;
            }
            return 0;
        }
        public int GetExistingDirector(Director director)
        {
            var existingDirector = _context.Directors
                 .Where(x => x.FirstName == director.FirstName && x.LastName == director.LastName)
                 .AsNoTracking() // No tracking of the entity
                 .FirstOrDefault();
            if (existingDirector != null)
            {
                return existingDirector.Id;
            }
            return 0;
        }
        public async Task<IEnumerable<MovieDTO>> GetAllMovies()
        {
            var result = await _context.Movies
                .Include(x => x.Actors)
                .Include(x => x.Director)
                .ToListAsync();

            var movies = result.MapToDto();

            return movies;
        }

        public async Task<MovieDTO> GetMovieById(int id)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            var movie = result.MapToDto();
            return movie;
        }

   
    }
}
