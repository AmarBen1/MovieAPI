using FluentValidation;
using MovieAPI.Domain;

namespace MovieAPI.Validation
{
    public class NewMovieValidator : AbstractValidator<Movie>
    {
        public NewMovieValidator()
        {
            //RuleFor(x=>x.Actors.Select(x=>x.Id).Must(x.)
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Movie field can't be empty");
        }


    }
}
