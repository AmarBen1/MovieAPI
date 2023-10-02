using FluentValidation;
using MovieAPI.Domain;

namespace MovieAPI.Validation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        { 
            RuleFor(x => x.Title).NotEmpty().Length(1, 20);
            RuleFor(x => x.Director.FirstName).NotEmpty().Length(1, 20);
            RuleFor(x => x.Director.LastName).NotEmpty().Length(1, 20);
        }
    }
}
