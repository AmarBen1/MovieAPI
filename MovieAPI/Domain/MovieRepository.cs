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
        public async Task<IEnumerable<MovieDTO>> GetAllMovies()
        {
            var result = await _context.Movies
                .Include(x => x.Actors)
                .Include(x => x.Director)
                .ToListAsync();
            var movies = DtoExtension.MapToDto(result);
            //var movies = from movie in result
            //             select new MovieDTO
            //             {
            //                 Title = movie.Title,
            //                 Director = $"{movie.Director.FirstName} {movie.Director.LastName}",
            //                 ReleaseYear = movie.ReleaseYear,
            //                 Budget = movie.Budget.ToString("C0", new CultureInfo("en-US")),
            //                 //Budget = $"{movie.Budget} $",
            //                 Actors = movie.Actors.Select(x => $"{x.FirstName} {x.LastName}")
            //             };

            return movies;
        }
    }
}
