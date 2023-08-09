using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTOs;
using MovieAPI.Interfaces;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _movieRepository.GetAllMovies();

            var movies = from movie in result
                         select new MovieDTO
                         {
                             Title = movie.Title,
                             Director = $"{movie.Director.FirstName} {movie.Director.LastName}",
                             ReleaseYear = movie.ReleaseYear,
                             Budget = $"{movie.Budget} $",
                             Actors = movie.Actors.Select(x=>$"{x.FirstName} {x.LastName}")
                         };

            return Ok(movies);
        }
    }
}
