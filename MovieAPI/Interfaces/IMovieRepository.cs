using MovieAPI.Domain;
using MovieAPI.DTOs;

namespace MovieAPI.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieDTO>> GetAllMovies();
    }
}
