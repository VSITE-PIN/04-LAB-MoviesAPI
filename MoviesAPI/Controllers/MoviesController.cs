using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly MoviesService _moviesService;

		public MoviesController(MoviesService moviesService)
		{
			_moviesService = moviesService;
		}

		[HttpGet]
		public IActionResult GetAllMovies() => Ok(_moviesService.GetAllMovies());

		[HttpGet("{id}")]
		public IActionResult GetMovieById(int id)
		{
			var movie = _moviesService.GetMovieById(id);
			if (movie == null) return NotFound();
			return Ok(movie);
		}

		[HttpPost]
		public IActionResult AddMovie([FromBody] Movie movie)
		{
			_moviesService.AddMovie(movie);
			return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
		{
			_moviesService.UpdateMovie(id, movie);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMovie(int id)
		{
			_moviesService.DeleteMovie(id);
			return NoContent();
		}
	}
}
