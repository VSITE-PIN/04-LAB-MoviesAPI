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

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public Movie UpdateMovieById(int id, Movie movie)
        {
            var dbMovie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (dbMovie != null)
            {
                dbMovie.Name = movie.Name;
                dbMovie.Year = movie.Year;
                dbMovie.Genre = movie.Genre;
                _context.SaveChanges();
            }

            return dbMovie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
