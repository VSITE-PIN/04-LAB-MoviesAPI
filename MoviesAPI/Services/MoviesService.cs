using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;

namespace MoviesAPI.Services
{
	public class MoviesService
	{
		private readonly MoviesDbContext _context;

		public MoviesService(MoviesDbContext context)
		{
			_context = context;
		}

		// Dohvaćanje svih filmova
		public async Task<List<Movie>> GetAllMoviesAsync()
		{
			return await _context.Movies.ToListAsync();
		}

		// Dohvaćanje jednog filma po ID-u
		public async Task<Movie?> GetMovieByIdAsync(int id)
		{
			return await _context.Movies.FindAsync(id);
		}

		// Dodavanje novog filma
		public async Task AddMovieAsync(Movie movie)
		{
			_context.Movies.Add(movie);
			await _context.SaveChangesAsync();
		}

		// Ažuriranje postojećeg filma
		public async Task UpdateMovieAsync(Movie movie)
		{
			_context.Movies.Update(movie);
			await _context.SaveChangesAsync();
		}

		// Brisanje filma
		public async Task DeleteMovieAsync(int id)
		{
			var movie = await GetMovieByIdAsync(id);
			if (movie != null)
			{
				_context.Movies.Remove(movie);
				await _context.SaveChangesAsync();
			}
		}
	}
}
