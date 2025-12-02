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

        // DODAVANJE FILMA
        public Movie AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        // DOHVAT SVIH FILMOVA
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        // DOHVAT JEDNOG FILMA PREKO ID-a
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        // AŽURIRANJE FILMA
        public Movie UpdateMovieById(int id, Movie updatedMovie)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                movie.Name = updatedMovie.Name;
                movie.Year = updatedMovie.Year;
                movie.Genre = updatedMovie.Genre;

                _context.SaveChanges();
            }

            return movie;
        }

        // BRISANJE FILMA
        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

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
