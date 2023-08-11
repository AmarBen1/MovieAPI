using MovieAPI.Domain;
using MovieAPI.DTOs;

namespace MovieAPI.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieDTO>> GetAllMovies();
        Movie AddMovie(Movie movie);
        Task<MovieDTO> GetMovieById(int id);
        Actor CheckForExistingActor(Movie movie);
    }
}
