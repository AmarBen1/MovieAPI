using MovieAPI.Domain;
using MovieAPI.DTOs;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MovieAPI.Extensions
{
    public static class DtoExtension
    {
        public static IEnumerable<MovieDTO> ToDto(this IEnumerable<Movie> movies)
        {
            return movies.Select(x => x.ToDto());
        }

        public static MovieDTO ToDto(this Movie movie)
        {
            var dto = new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = new Director { Id = movie.Director.Id, FirstName = movie.Director.FirstName, LastName=movie.Director.LastName },
                Genre = movie.Genre,
                TrailerPath = movie.TrailerPath,
                ReleaseYear = movie.ReleaseYear,
                Duration = movie.Duration,
                Actors = movie.Actors.Select(x=>new Actor { Id=x.Id, FirstName=x.FirstName, LastName=x.LastName })               
            };
            return dto;
        }
    }
}
