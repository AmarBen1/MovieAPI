using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
        public Genre? Genre { get; set; }
        public string? Duration { get; set; }
        public int? ReleaseYear { get; set; }
        public string? TrailerPath { get; set; }
        public ICollection<Actor>? Actors { get; set; }
    }
}
