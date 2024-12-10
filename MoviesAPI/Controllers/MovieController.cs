using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

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
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.id }, newMovie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var existingMovie = _moviesService.GetMovieById(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            updatedMovie.id = id;
            _moviesService.UpdateMovie(updatedMovie);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var existingMovie = _moviesService.GetMovieById(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            _moviesService.DeleteMovie(id);
            return NoContent();
        }
    }
}

