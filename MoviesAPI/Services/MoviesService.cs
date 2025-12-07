using MoviesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MoviesContext _context;

        public MoviesService(MoviesContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public bool Update(int id, Movie movie)
        {
            var existing = _context.Movies.Find(id);
            if (existing == null) return false;

            existing.Name = movie.Name;
            existing.Year = movie.Year;
            existing.Genre = movie.Genre;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }
    }
}
