using MoviesAPI.Data;
using Microsoft.EntityFrameworkCore;

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

        public Movie? GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie AddMovie(Movie movies)
        {
            var movie = new Movie
            {
                Name = movies.Name,
                Year = movies.Year,
                Genre =movies.Genre
            };
            _context.Movies.Add(movies);
            _context.SaveChanges();
            return movie;
        }

        public Movie? UpdateMovieById(int id, Movie movies)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movies != null)
            {
                movies.Name = movies.Name;
                movies.Year = movies.Year;
                movies.Genre = movies.Genre;
                _context.SaveChanges();
            }
            return movies;
        }

        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return false;
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }
    }
}
