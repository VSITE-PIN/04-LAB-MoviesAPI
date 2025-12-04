using MoviesAPI.Data;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;

        // Konstruktor: pristup bazi podataka
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        // 1. Dohvaćanje svih filmova
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        // 2. Dohvaćanje jednog filma po ID-u
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(n => n.Id == id);
        }

        // 3. Dodavanje novog filma
        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        // 4. Ažuriranje filma
        public Movie UpdateMovie(int id, Movie moviePodaci)
        {
            var postojeciFilm = _context.Movies.FirstOrDefault(n => n.Id == id);

            if (postojeciFilm != null)
            {
                // Ažuriramo podatke
                postojeciFilm.Name = moviePodaci.Name;
                postojeciFilm.Year = moviePodaci.Year;
                postojeciFilm.Genre = moviePodaci.Genre;

                _context.SaveChanges();
            }
            return postojeciFilm;
        }

        // 5. Brisanje filma
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(n => n.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}