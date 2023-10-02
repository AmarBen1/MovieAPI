using MovieAPI.Domain;
using MovieAPI.DTOs;

namespace MovieAPI.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieDTO>> GetAllMovies();
        //Movie AddMovie(Movie movie);
        Task<Movie> AddMovie(Movie movie);
        Task<MovieDTO> GetMovieById(int id);
        Task<IEnumerable<MovieDTO>> GetMoviesByTitle(string movieTitle);
        Task<MovieDTO> GetMoviesByYear(int ReleaseYear);
        Task<Movie> UpdateMovie(Movie movie);
        void DeleteMovie(int id);
        int GetExistingActor(Actor actor);
        int GetExistingDirector(Director director);
    }
}
