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
        // 1. Dohvat svih filmova
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        // 2. Dohvat jednog filma po ID-u
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        // 3. Dodavanje filma
        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        //4. Ažuriranje filma
        public Movie UpdateMovie(int id, Movie updateMovie)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                movie.Name = updateMovie.Name;
                movie.Year = updateMovie.Year;
                movie.Genre = updateMovie.Genre;

                _context.SaveChanges();
            }

            return movie;
        }

        //5. Brisanje filma
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
