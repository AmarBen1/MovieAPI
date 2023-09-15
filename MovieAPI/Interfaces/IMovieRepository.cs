using MovieAPI.Domain;
using MovieAPI.DTOs;

namespace MovieAPI.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieDTO>> GetAllMovies();
        Task<IEnumerable<Movie>> GetMovies();
        Movie AddMovie(Movie movie);
        Task<MovieDTO> GetMovieById(int id);
        Task<Movie> UpdateMovie(Movie movie);
        int GetExistingActor(Actor actor);
        int GetExistingDirector(Director director);
    }
}
