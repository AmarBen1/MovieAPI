using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain;

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
                  { Id = 4, FirstName = "Damon", LastName = "Wayans" });

            modelBuilder.Entity<Director>().HasData(
                new Director
                { Id = 1, FirstName = "Joseph", LastName = "Kosinski" },
                new Director
                { Id = 2, FirstName = "Tony", LastName = "Scott" });

           modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Top Gun : Maverick",
                    DirectorId = 1,
                    Budget = 150000000,
                    ReleaseYear = 2022    
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Last Boy Scout",
                    DirectorId = 2,
                    Budget = 30000000,
                    ReleaseYear = 1991
                });
        }
    }
}
