using MoviesAPI.Data;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public Movie UpdateMovie(int id, Movie movie)
        {
            var existingMovie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie != null)
            {
                existingMovie.Name = movie.Name;
                existingMovie.Year = movie.Year;
                existingMovie.Genre = movie.Genre;
                _context.SaveChanges();
            }
            return existingMovie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}