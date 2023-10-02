using MovieAPI.Domain;

namespace MovieAPI.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
        public string? TrailerPath { get; set; }
        public Genre? Genre { get; set; }
        public string? Duration { get; set; }
        public int? ReleaseYear { get; set; }
        public IEnumerable<Actor>? Actors { get; set; }
    }
}
