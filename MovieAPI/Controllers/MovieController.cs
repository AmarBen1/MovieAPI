using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Domain;
using MovieAPI.Interfaces;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IValidator<Movie> _movieValidator;

        public MovieController(IMovieRepository movieRepository, IValidator<Movie> movieValidator)
        {
            _movieRepository = movieRepository;
            _movieValidator = movieValidator;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewMovie(Movie movie)
        {
            var validationResult = _movieValidator.Validate(movie);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var existingDirectorId = _movieRepository.GetExistingDirector(movie.Director);
            if (existingDirectorId != 0)
            {
                movie.Director.Id = existingDirectorId;
            }

            foreach (Actor actor in movie.Actors)
            {
                var existingActorId = _movieRepository.GetExistingActor(actor);
                if (existingActorId != 0)
                {
                    actor.Id = existingActorId;
                }
            }

            var result = await _movieRepository.AddMovie(movie);

            return Ok(result);
        }

        //[HttpPost]
        //public IActionResult AddNewMovie(Movie movie)
        //{
        //    //var validationResult = _movieValidator.Validate(movie);

        //    //if (!validationResult.IsValid)
        //    //{
        //    //    return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
        //    //}

        //    var existingDirectorId = _movieRepository.GetExistingDirector(movie.Director);
        //    if (existingDirectorId != 0)
        //    {
        //        movie.Director.Id = existingDirectorId;
        //    }

        //    foreach (Actor actor in movie.Actors)
        //    {
        //        var existingActorId = _movieRepository.GetExistingActor(actor);
        //        if (existingActorId != 0)
        //        {
        //            actor.Id = existingActorId;
        //        }
        //    }

        //    var result = _movieRepository.AddMovie(movie);

        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieRepository.GetAllMovies();

            return Ok(movies);
        }

        [HttpPut("{id}")] //to do
        public async Task<IActionResult> UpdateMovie(int id)
        {
            var res = await _movieRepository.GetMovieById(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);

            return Ok(movie);
        }
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            if (movieId == 0)
            {
                return BadRequest();
            }

            var movie = await _movieRepository.GetMovieById(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                _movieRepository.DeleteMovie(movieId);
                return NoContent();
            }
        }

        [HttpGet("title")]
        public async Task<IActionResult> GetMoviesByTitle(string title)
        {
            var movies = await _movieRepository.GetMoviesByTitle(title);

            return Ok(movies);
        }
    }
}









