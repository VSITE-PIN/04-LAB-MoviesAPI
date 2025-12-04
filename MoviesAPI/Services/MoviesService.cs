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
        public void AddMovie(MovieVm movie)
        {
            var newMovie = new Movie()
            {
                Movie = movie.Title,
                Description = movie.Description,
                IsWatched = movie.IsWatched,
                Rate = movie.IsWatched ? movie.Rate : null,
                Genre = movie.Genre,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

    }
}
