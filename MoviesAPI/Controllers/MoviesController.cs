using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly MoviesService _service;

		public MoviesController(MoviesService service)
		{
			_service = service;
		}

		// GET: api/Movies
		[HttpGet]
		public async Task<ActionResult<List<Movie>>> GetAllMovies()
		{
			var movies = await _service.GetAllMoviesAsync();
			return Ok(movies);
		}

		// GET: api/Movies/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> GetMovieById(int id)
		{
			var movie = await _service.GetMovieByIdAsync(id);
			if (movie == null)
				return NotFound();

			return Ok(movie);
		}

		// POST: api/Movies
		[HttpPost]
		public async Task<ActionResult> AddMovie(Movie movie)
		{
			await _service.AddMovieAsync(movie);
			return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
		}

		// PUT: api/Movies/{id}
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateMovie(int id, Movie movie)
		{
			if (id != movie.Id)
				return BadRequest();

			await _service.UpdateMovieAsync(movie);
			return NoContent();
		}

		// DELETE: api/Movies/{id}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteMovie(int id)
		{
			await _service.DeleteMovieAsync(id);
			return NoContent();
		}
	}
}
