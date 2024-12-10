﻿using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MoviesService
    {

        AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Movie>> GetMoviesAsync()
        {
            var result = _context.Movies;
            return await Task.FromResult(result.ToList());
        }
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }
        public async Task<Movie> InsertMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<Movie> UpdateMovieAsync(int id, Movie m)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return null;
            movie.Id = m.Id;
            movie.Name = m.Name;
            movie.Year = m.Year;
            movie.Genre = m.Genre;

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return false;

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return true;
        }
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

    }
}
