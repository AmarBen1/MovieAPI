using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain;
using System;

namespace MovieAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genres> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Actor>().HasData(
                 new Actor
                 { Id = 1, FirstName = "Tom", LastName = "Cruise" },
                 new Actor
                 { Id = 2, FirstName = "Miles", LastName = "Teller" },
                 new Actor
                 { Id = 3, FirstName = "Bruce", LastName = "Willis" },
                 new Actor
                 { Id = 4, FirstName = "Damon", LastName = "Wayans" },
                 new Actor
                 { Id = 5, FirstName = "Dustin", LastName = "Hoffman" },
                 new Actor
                 { Id = 6, FirstName = "Clint", LastName = "Eastwood" },
                 new Actor
                 { Id = 7, FirstName = "Lee", LastName = "Van Cleef" },
                 new Actor
                 { Id = 8, FirstName = "Eli", LastName = "Wallach" },
                 new Actor
                 { Id = 9, FirstName = "Sigourney", LastName = "Weaver" },
                 new Actor
                 { Id = 10, FirstName = "Tom", LastName = "Skerritt" });


            modelBuilder.Entity<Director>().HasData(
                new Director
                { Id = 1, FirstName = "Joseph", LastName = "Kosinski" },
                new Director
                { Id = 2, FirstName = "Tony", LastName = "Scott" },
                new Director
                { Id = 3, FirstName = "Barry", LastName = "Levinson" },
                new Director
                { Id = 4, FirstName = "Sergio", LastName = "Leone" },
                new Director
                { Id = 5, FirstName = "Ridley", LastName = "Scott" });

            modelBuilder.Entity<Genres>().HasData(
                new Genres
                { Id = 1, Genre = "Action" },
                new Genres
                { Id = 2, Genre = "Comedy" },
                new Genres
                { Id = 3, Genre = "Science-Fiction" },
                 new Genres
                { Id = 4, Genre = "Drama" },
                 new Genres
                { Id = 5, Genre = "Western" },
                 new Genres
                { Id = 6, Genre = "Thriller" });

            modelBuilder.Entity<Movie>().HasData(
                 new Movie
                 {
                     Id = 1,
                     Title = "Top Gun : Maverick",
                     DirectorId = 1,
                     Duration = "2h 10m",
                     TrailerPath = "https://www.youtube.com/embed/giXco2jaZ_4?si=bhuGz4-cg-ka5dqa",
                     GenreId = 1,
                     ReleaseYear = 2022
                 },
                 new Movie
                 {
                     Id = 2,
                     Title = "The Last Boy Scout",
                     DirectorId = 2,
                     Duration = "1h 45m",
                     TrailerPath = "https://www.youtube.com/embed/NPO-Z6mEYW4?si=LAxOH9CVyWYpFjMX",
                     GenreId = 1,
                     ReleaseYear = 1991
                 },
                 new Movie
                 {
                     Id = 3,
                     Title = "Rain Man",
                     DirectorId = 3,
                     Duration = "2h 13m",
                     TrailerPath = "https://www.youtube.com/embed/mlNwXuHUA8I?si=Ho7AiWBMwWx2HpO6",
                     GenreId = 4,
                     ReleaseYear = 1988
                 },
                 new Movie
                 {
                     Id = 4,
                     Title = "The Good, the Bad and the Ugly",
                     DirectorId = 4,
                     Duration = "2h 58m",
                     TrailerPath = "https://www.youtube.com/embed/IFNUGzCOQoI?si=a96JJzg1QCRcJrK5",
                     GenreId = 5,
                     ReleaseYear = 1966
                 },
                 new Movie
                 {
                     Id = 5,
                     Title = "Alien",
                     DirectorId = 5,
                     Duration = "1h 57m",
                     TrailerPath = "https://www.youtube.com/embed/jQ5lPt9edzQ?si=caTNcXcqcHE2p1d-",
                     GenreId = 3,
                     ReleaseYear = 1979
                 },
                 new Movie
                 {
                     Id = 6,
                     Title = "For a Few Dollar More",
                     DirectorId = 4,
                     Duration = "2h 12m",
                     TrailerPath = "https://www.youtube.com/embed/bNt9NcLteoU?si=U6ZFghGM58QWbfD9",
                     GenreId = 5,
                     ReleaseYear = 1965
                 });
        }
    }
}
