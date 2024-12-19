using MoviesAPI.Data;
using System;

namespace MoviesAPI.Services
{
	public class MoviesService
	{
		private MovieDbContext _context;
		public MoviesService(MovieDbContext context)
		{

			_context = context;

		}

		public List<Movie> GetAllMovies() => _context.Movies.ToList();

		public Movie GetMovieById(int id) => _context.Movies.FirstOrDefault(m => m.Id == id);

		public void AddMovie(Movie movie)
		{
			_context.Movies.Add(movie);
			_context.SaveChanges();
		}

		public void UpdateMovie(int id, Movie updatedMovie)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			if (movie != null)
			{
				movie.Name = updatedMovie.Name;
				movie.Year = updatedMovie.Year;
				movie.Genre = updatedMovie.Genre;
				_context.SaveChanges();
			}
		}

		public void DeleteMovie(int id)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			if (movie != null)
			{
				_context.Movies.Remove(movie);
				_context.SaveChanges();
			}
		}
	}	
}
