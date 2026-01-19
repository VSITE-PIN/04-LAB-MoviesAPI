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

        
        public Movie AddMovie(MovieVM movieVM)
        {
            var newMovie = new Movie
            {
                Name = movieVM.Name,
                Year = movieVM.Year,
                Genre = movieVM.Genre
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return newMovie;
        }

        
        public Movie? UpdateMovieById(int id, MovieVM movieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return null;

            movie.Name = movieVM.Name;
            movie.Year = movieVM.Year;
            movie.Genre = movieVM.Genre;

            _context.SaveChanges();
            return movie;
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
