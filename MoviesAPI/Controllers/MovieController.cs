using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesService _moviesService;

        public MovieController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _moviesService.GetAllMovies();
            return Ok(movies);
        }

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
            var newMovie = _moviesService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieById(int id, [FromBody] Movie movie)
        {
            var updated = _moviesService.UpdateMovieById(id, movie);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var success = _moviesService.DeleteMovie(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}