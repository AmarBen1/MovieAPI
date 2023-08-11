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
            var actors = new List<Actor>() 
            {
                 new Actor { Id = 0,  FirstName = "Tom",  LastName = "Cruise" }
            };
            var movie = new Movie 
            {
                Title = "Test",
                Actors = actors          
            };
        
            var existingActor = new Actor { Id = 1, FirstName = "Tom", LastName = "Cruise" };

            var mock = new Mock<IMovieRepository>();     
            mock.Setup(x=>x.CheckForExistingActor(movie)).Returns(existingActor);
            var sut = new MovieController(mock.Object);

            var result = sut.AddNewMovie(movie);
            var actor = result.Actors.ToList();

            Assert.Equal(1, actor[0].Id);

        }
    }
}
