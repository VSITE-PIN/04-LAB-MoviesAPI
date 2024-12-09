using System.Collections.Generic;
using System.Linq;

namespace YourProjectNamespace.Services
{
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public int Year { get; set; }
	}

	public class MoviesService
	{
		private readonly List<Movie> _movies;

		public MoviesService()
		{
			// Inicijalizacija sa nekim demo podacima
			_movies = new List<Movie>
			{
				new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Year = 2010 },
				new Movie { Id = 2, Title = "The Godfather", Genre = "Crime", Year = 1972 },
				new Movie { Id = 3, Title = "The Dark Knight", Genre = "Action", Year = 2008 }
			};
		}

		// Dohvaćanje svih filmova
		public IEnumerable<Movie> GetAllMovies()
		{
			return _movies;
		}

		// Dohvaćanje jednog filma preko ID-a
		public Movie GetMovieById(int id)
		{
			return _movies.FirstOrDefault(m => m.Id == id);
		}

		// Dodavanje novog filma
		public void AddMovie(Movie movie)
		{
			// Generiranje ID-a za novi film
			movie.Id = _movies.Max(m => m.Id) + 1;
			_movies.Add(movie);
		}

		// Ažuriranje postojećeg filma
		public bool UpdateMovie(int id, Movie updatedMovie)
		{
			var movie = _movies.FirstOrDefault(m => m.Id == id);
			if (movie == null)
			{
				return false;
			}

			movie.Title = updatedMovie.Title;
			movie.Genre = updatedMovie.Genre;
			movie.Year = updatedMovie.Year;
			return true;
		}

		// Brisanje filma
		public bool DeleteMovie(int id)
		{
			var movie = _movies.FirstOrDefault(m => m.Id == id);
			if (movie == null)
			{
				return false;
			}

			_movies.Remove(movie);
			return true;
		}
	}
}
