using Microsoft.AspNetCore.Mvc;
using YourProjectNamespace.Services;

namespace YourProjectNamespace.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MoviesController : ControllerBase
	{
		private readonly MoviesService _moviesService;

		public MoviesController(MoviesService moviesService)
		{
			_moviesService = moviesService;
		}

		[HttpGet]
		public IActionResult GetAllMovies()
		{
			return Ok(_moviesService.GetAllMovies());
		}

		[HttpGet("{id}")]
		public IActionResult GetMovieById(int id)
		{
			var movie = _moviesService.GetMovieById(id);
			if (movie == null)
			{
				return NotFound();
			}

			return Ok(movie);
		}

		[HttpPost]
		public IActionResult AddMovie([FromBody] Movie newMovie)
		{
			_moviesService.AddMovie(newMovie);
			return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
		{
			var result = _moviesService.UpdateMovie(id, updatedMovie);
			if (!result)
			{
				return NotFound();
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMovie(int id)
		{
			var result = _moviesService.DeleteMovie(id);
			if (!result)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
