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

        // GET: api/movies
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _moviesService.GetAllMovies();
            return Ok(movies);
        }

        // GET: api/movies/5
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

        // POST: api/movies
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            var createdMovie = _moviesService.AddMovie(movie);
            // vraćamo 201 + lokaciju resursa
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            var updatedMovie = _moviesService.UpdateMovie(id, movie);

            if (updatedMovie == null)
            {
                return NotFound();
            }

            return Ok(updatedMovie);
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var deleted = _moviesService.DeleteMovie(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
