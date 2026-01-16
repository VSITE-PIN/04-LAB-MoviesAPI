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

        // GET: api/Movies
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _moviesService.GetAllMovies();
            return Ok(movies);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _moviesService.GetMovieById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newMovie = _moviesService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovieById),
                                   new { id = newMovie.Id },
                                   newMovie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedMovie = _moviesService.UpdateMovie(id, movie);
            if (updatedMovie == null) return NotFound();

            return Ok(updatedMovie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var ok = _moviesService.DeleteMovie(id);
            if (!ok) return NotFound();

            return NoContent();
        }
    }
}
