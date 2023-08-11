using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.DTOs;
using MovieAPI.Extensions;
using MovieAPI.Interfaces;
using System.Globalization;

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
            foreach (Actor actor in movie.Actors)
            {
                var existingActor = _context.Actors
                    .Where(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName)
                    .AsNoTracking() // No tracking of the entity
                    .FirstOrDefault();
                if (existingActor != null)
                {
                    actor.Id = existingActor.Id;
                }
            }
            return movie;
        }

        public Actor CheckForExistingActor(Movie movie)
        {
            var existingActor = _context.Actors
                   .Where(x => x.FirstName == movie.Actors.) == //.FirstName && x.LastName == actor.LastName)
                   .AsNoTracking() // No tracking of the entity
                   .FirstOrDefault();

            return existingActor;
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
            var result = await _context.Movies.FirstOrDefaultAsync(x=>x.Id == id);
            var movie = result.MapToDto();
            return movie;
        }

        //Actor GetExistingActors(Movie movie)
        //{
        //    var existingActor = _context.Actors
        //           .Where(x => x.FirstName == movie.Actors.) == //.FirstName && x.LastName == actor.LastName)
        //           .AsNoTracking() // No tracking of the entity
        //           .FirstOrDefault();

        //    return existingActor;
        //}
    }
}
