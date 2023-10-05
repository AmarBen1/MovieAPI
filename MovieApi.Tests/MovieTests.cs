using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieAPI.Controllers;
using MovieAPI.Domain;
using MovieAPI.Interfaces;
using MovieAPI.Validation;

namespace MovieApi.Tests
{
    public class MovieTests
    {
        [Fact]
        public async Task AddMovieShouldNotCreateNewActorIfItExists()
        {
            var existingActor = new Actor { Id = 2, FirstName = "Tom", LastName = "Cruise" };
            var movie = new Movie
            {
                Title = "Top Gun",
                Actors = new List<Actor>
                {
                    new Actor { Id = 0, FirstName = "Tom", LastName = "Cruise" }
                }
            };

            var validator = new MovieValidator();
            var mock = new Mock<IMovieRepository>();
            mock.Setup(x => x.GetExistingActor(It.IsAny<Actor>())).Returns(3);//(existingActor.Id);
            mock.Setup(x => x.AddMovie(It.IsAny<Movie>())).ReturnsAsync(movie);

            var sut = new MovieController(mock.Object, validator);

            var result = await sut.AddNewMovie(movie);

            var okResult = Assert.IsType<OkObjectResult>(result);
           
            var returnedMovie = Assert.IsType<Movie>(okResult.Value);
            var actors = returnedMovie.Actors.ToList();

            Assert.Equal(existingActor.Id, actors[0].Id);
        }

        //[Fact]
        //public void AddMovieShouldCreateNewActorIfItDoesNotExists()
        //{
        //    var movie = new Movie
        //    {
        //        Title = "Top Gun",
        //        Actors = new List<Actor>
        //        {
        //            new Actor { Id = 0, FirstName = "Tom", LastName = "Cruise" }
        //        }
        //    };

        //    var mock = new Mock<IMovieRepository>();
        //    mock.Setup(x => x.GetExistingActor(It.IsAny<Actor>())).Returns(0);
        //    mock.Setup(x => x.AddMovie(It.IsAny<Movie>())).Returns(movie);

        //    var sut = new MovieController(mock.Object);

        //    var result = sut.AddNewMovie(movie);
        //    var actors = result.Actors.ToList();

        //    Assert.Equal(0, actors[0].Id);
        //}

        //[Fact]
        //public void AddMovieShouldNotCreateNewDirectorIfItExists()
        //{
        //    var existingDirector = new Director { Id = 2, FirstName = "Tony", LastName = "Scott" };
        //    var movie = new Movie
        //    {
        //        Title = "Top Gun",
        //        Director = new Director { Id = 0, FirstName = "Tony", LastName = "Scott" },
        //        Actors = new List<Actor>
        //        {
        //            new Actor { Id = 0, FirstName = "Tom", LastName = "Cruise" }
        //        }
        //    };

        //    var mock = new Mock<IMovieRepository>();
        //    mock.Setup(x => x.GetExistingActor(It.IsAny<Actor>())).Returns(0);
        //    mock.Setup(x => x.GetExistingDirector(It.IsAny<Director>())).Returns(existingDirector.Id);
        //    mock.Setup(x => x.AddMovie(It.IsAny<Movie>())).Returns(movie);            

        //    var sut = new MovieController(mock.Object);

        //    var result = sut.AddNewMovie(movie);            

        //    Assert.Equal(2, result.Director.Id);
        //}



    }
}
