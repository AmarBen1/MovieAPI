using MovieAPI.Domain;
using MovieAPI.DTOs;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MovieAPI.Extensions
{
    public static class DtoExtension
    {
        public static IEnumerable<MovieDTO> MapToDto(this IEnumerable<Movie> movies)
        {
            return movies.Select(x => x.MapToDto());
        }

        public static MovieDTO MapToDto(this Movie movie)
        {
            var dto = new MovieDTO
            {
                Title = movie.Title,
                Director = $"{movie.Director.FirstName} {movie.Director.LastName}",
                ReleaseYear = movie.ReleaseYear,
                Budget = movie.Budget.ToString("C0", new CultureInfo("en-US")),
                //Budget = $"{movie.Budget} $",
                Actors = movie.Actors.Select(x => $"{x.FirstName} {x.LastName}")

            };
            return dto;
        }
    }
}
