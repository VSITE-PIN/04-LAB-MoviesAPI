using MoviesAPI.Data;

namespace MoviesAPI.Services;

public class MoviesService
{
    private AppDbContext _context;

    public MoviesService(AppDbContext context)
    {
        _context = context;
    }

    public void AddMovie(MoviesVM movies)
    {
        var newMovie = new Movies()
        {
            Name = movies.Name,
            Year = movies.Year,
            Genre = movies.Genre,
        };
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
    }

    public List<Movies> GetAllMovies()
    {
        return _context.Movies.ToList();
    }

    public Movies GetMovieById(int id)
    {
        return _context.Movies.FirstOrDefault(x => x.Id==id);
    }

    public Movies UpdateMoviesById(int id, MoviesVM moviesVm)
    {
        var movies = _context.Movies.FirstOrDefault(x => x.Id == id);
        if (movies != null)
        {
            Movies.Name = moviesVm.Name;
            Movies.Genre = moviesVm.Genre;
            Movies.Year = moviesVm.Year;
            _context.SaveChanges();
        }

        return movies;
    }
}