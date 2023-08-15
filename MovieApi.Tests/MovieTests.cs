using Moq;
using MovieAPI.Controllers;
using MovieAPI.Domain;
using MovieAPI.Interfaces;

namespace MovieApi.Tests
{
    public class MovieTests
    {
        [Fact]
        public void AddMovieShouldNotCreateNewActorIfItExists()
        {      
            var existingActor = new Actor { Id = 1, FirstName = "Tom", LastName = "Cruise" };      

            var movie = new Movie
            {
                Title = "Top Gun",
                Actors = new List<Actor>
                {
                    new Actor { Id = 0, FirstName = "Tom", LastName = "Cruise" }                    
                }
            };

            var mock = new Mock<IMovieRepository>();     
            mock.Setup(x => x.GetExistingActor(It.IsAny<Actor>())).Returns(existingActor.Id);
            mock.Setup(x=>x.AddMovie(It.IsAny<Movie>())).Returns(movie);

            var sut = new MovieController(mock.Object);

            var result =  sut.AddNewMovie(movie);
            var actors = result.Actors.ToList();

            Assert.Equal(1, actors[0].Id);         
        }

        [Fact]
        public void AddMovieShouldCreateNewActorIfItNotExists()
        {
            var movie = new Movie
            {
                Title = "Top Gun",
                Actors = new List<Actor>
                {
                    new Actor { Id = 0, FirstName = "Tom", LastName = "Cruise" }
                }
            };

            var mock = new Mock<IMovieRepository>();
            mock.Setup(x => x.GetExistingActor(It.IsAny<Actor>())).Returns(null);
            mock.Setup(x => x.AddMovie(It.IsAny<Movie>())).Returns(movie);

            var sut = new MovieController(mock.Object);

            var result = sut.AddNewMovie(movie);
            var actors = result.Actors.ToList();

            Assert.Equal(0, actors[0].Id);
        }

        [Fact]
        public void AddMovie()
        {
            var existingDirector = new Director { Id = 2, FirstName = "Tony", LastName = "Scott" };
            var movie = new Movie
            {
                Title = "Top Gun",
                Director = new Director { Id = 0, FirstName = "Tony", LastName = "Scott" },
                Actors = new List<Actor>
                {
                    new Actor { Id = 0, FirstName = "Tom", LastName = "Cruise" }
                }
            };

            var mock = new Mock<IMovieRepository>();
            mock.Setup(x => x.GetExistingActor(It.IsAny<Actor>())).Returns(null);
            mock.Setup(x => x.GetExistingDirector(It.IsAny<Director>())).Returns(existingDirector.Id);
            mock.Setup(x => x.AddMovie(It.IsAny<Movie>())).Returns(movie);

            var sut = new MovieController(mock.Object);

            var result = sut.AddNewMovie(movie);            

            Assert.Equal(2, result.Director.Id);
        }
    }
}
