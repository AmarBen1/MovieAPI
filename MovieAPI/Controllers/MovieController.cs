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
            foreach (Actor actor in movie.Actors)
            {
                var existingActorId = _movieRepository.GetExistingActor(actor);
                if (existingActorId != 0)
                {
                    actor.Id = existingActorId;
                }
            }

            var existingDirectorId = _movieRepository.GetExistingDirector(movie.Director);
            if (existingDirectorId != 0)
            {
                movie.Director.Id = existingDirectorId;
            }

            var result = _movieRepository.AddMovie(movie);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieRepository.GetAllMovies(); 

            return Ok(movies);
        }
    }
}
