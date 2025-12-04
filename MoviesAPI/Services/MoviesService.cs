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

        // 1) Dohvat svih filmova
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        // 2) Dohvat jednog filma po Id
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        // 3) Dodavanje filma
        public Movie AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        // 4) Ažuriranje filma
        public Movie UpdateMovie(int id, Movie movie)
        {
            var dbMovie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (dbMovie == null) return null;

            dbMovie.Name = movie.Name;
            dbMovie.Year = movie.Year;
            dbMovie.Genre = movie.Genre;

            _context.SaveChanges();
            return dbMovie;
        }

        // 5) Brisanje filma
        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }
    }
}
