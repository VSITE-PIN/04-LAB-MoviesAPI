using MoviesAPI.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private  AppDbContext _context;

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
            return _context.Movies.FirstOrDefault(movie => movie.id == id);
        }

        public void UpdateMovie(Movie updatedMovie)
        {
            var existingMovie = _context.Movies.FirstOrDefault(movie => movie.id == updatedMovie.id);
            if (existingMovie != null)
            {
                existingMovie.name = updatedMovie.name;
                existingMovie.year = updatedMovie.year;
                existingMovie.genre = updatedMovie.genre;

                _context.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = _context.Movies.FirstOrDefault(movie => movie.id == id);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
        }

        public void AddMovie(Movie newMovie)
        {   
            var movie = new Movie();
            {
                movie.name = newMovie.name;
                movie.year = newMovie.year;
                //movie.year = newMovie.year;
                movie.genre = newMovie.genre;
            };


            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        //internal void AddMovie(Movie newMovie)
        //{
            //throw new NotImplementedException();
        //}
    }
}

