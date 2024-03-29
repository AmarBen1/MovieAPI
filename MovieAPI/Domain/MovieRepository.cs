﻿using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.DTOs;
using MovieAPI.Extensions;
using MovieAPI.Interfaces;

namespace MovieAPI.Domain
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }

        //public  Movie AddMovie(Movie movie)
        //{
        //    _context.Update(movie);
        //    _context.SaveChanges();
        //    return movie;
        //}
        public int GetExistingActor(Actor actor)
        {
            var existingActor = _context.Actors
                .Where(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName)
                .AsNoTracking() // No tracking of the entity
                .FirstOrDefault();
            if (existingActor != null)
            {
                return existingActor.Id;
            }
            return 0;
        }
        public int GetExistingDirector(Director director)
        {
            var existingDirector = _context.Directors
                 .Where(x => x.FirstName == director.FirstName && x.LastName == director.LastName)
                 .AsNoTracking() // No tracking of the entity
                 .FirstOrDefault();
            if (existingDirector != null)
            {
                return existingDirector.Id;
            }
            return 0;
        }
        public async Task<IEnumerable<MovieDTO>> GetAllMovies()
        {
            var result = await _context.Movies
                .Include(x => x.Actors)
                .Include(x => x.Director)
                .ToListAsync();

            var movies = result.ToDto();

            return movies;
        }
        public async Task<MovieDTO> GetMovieById(int id)
        {
            var result = await _context.Movies.Include(x => x.Actors)
                                              .Include(x => x.Director)
                                              .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                var movie = result.ToDto();
                return movie;
            }
        }
        public async Task<Movie> UpdateMovie(Movie movie) //to do
        {
            return movie;
        }
        public void DeleteMovie(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(e => e.Id == movieId);
            _context.Movies.Remove(movie);
            _context.SaveChanges();

        }
        public async Task<IEnumerable<MovieDTO>> GetMoviesByTitle(string movieTitle)
        {
            var result = await _context.Movies.Include(x => x.Actors)
                                         .Include(x => x.Director)
                                         .Where(x => x.Title == movieTitle)
                                         .ToListAsync();

            var movies = result.ToDto();
            return movies;
        }
        public Task<MovieDTO> GetMoviesByYear(int ReleaseYear)
        {
            throw new NotImplementedException();
        }
    }
}
