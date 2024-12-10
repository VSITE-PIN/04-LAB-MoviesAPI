using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> UpdateMovie(int id, Movie updatedMovie)
        {
            var existingMovie = await _context.Movies.FindAsync(id);
            if (existingMovie == null)
            {
                return false;
            }

            existingMovie.Name = updatedMovie.Name;
            existingMovie.Year = updatedMovie.Year;
            existingMovie.Genre = updatedMovie.Genre;

            _context.Movies.Update(existingMovie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return false;
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}