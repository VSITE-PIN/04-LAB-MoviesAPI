using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        Movie Add(Movie movie);
        bool Update(int id, Movie movie);
        bool Delete(int id);
    }
}
