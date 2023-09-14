using System.IO;

namespace MovieAPI.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
        public int GenreId { get; set; }
        public Genres Genre { get; set; }
        public string Duration { get; set; }
        public int ReleaseYear { get; set; }
        public string TrailerPath { get; set; }
        public ICollection<Actor>? Actors { get; set; }
    }
}
