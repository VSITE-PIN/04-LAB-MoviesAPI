using System.Collections.Generic;
using System.Linq;
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

        // ➜ DOHVAĆANJE SVIH FILMOVA
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        // ➜ DOHVAĆANJE JEDNOG FILMA PREKO ID-A
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        // ➜ DODAVANJE FILMA
        public Movie AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        // ➜ AŽURIRANJE FILMA
        public Movie UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return null;
            }

            movie.Name = updatedMovie.Name;
            movie.Year = updatedMovie.Year;
            movie.Genre = updatedMovie.Genre;

            _context.SaveChanges();

            return movie;
        }

        // ➜ BRISANJE FILMA
        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return false;
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return true;
        }
    }
}
