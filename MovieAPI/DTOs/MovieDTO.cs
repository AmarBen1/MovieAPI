using MovieAPI.Domain;

namespace MovieAPI.DTOs
{
    public class MovieDTO
    {       
        public string Title { get; set; }       
        public string Director { get; set; }
        public string Budget { get; set; }
        public int ReleaseYear { get; set; }
        public IEnumerable<string>? Actors { get; set; }
    }
}
