using System.IO;

namespace MovieAPI.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int Budget { get; set; }
        public int ReleaseYear { get; set; }
        public ICollection<Actor>? Actors { get; set; }
    }
}
