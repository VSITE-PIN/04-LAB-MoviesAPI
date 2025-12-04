using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
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
        public Movie UpdateMovieById(int id, Movie movie)
        {
            var updatemovie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (updatemovie != null)
            {
                updatemovie.Name = movie.Name;
                updatemovie.Year = movie.Year;
                updatemovie.Genre = movie.Genre;
                _context.SaveChanges();
            }
            return updatemovie;
        }
        public void DeleteMovie(int id)
        {
            var deletebook = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(deletebook);
            _context.SaveChanges();
        }
        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
