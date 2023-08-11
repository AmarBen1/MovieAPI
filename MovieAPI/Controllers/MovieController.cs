using Microsoft.AspNetCore.Mvc;
using MovieAPI.Domain;
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

        [HttpPost]
        public Movie AddNewMovie(Movie movie)
        {
            var result = _movieRepository.AddMovie(movie);
            return movie;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieRepository.GetAllMovies(); 

            return Ok(movies);
        }
    }
}
