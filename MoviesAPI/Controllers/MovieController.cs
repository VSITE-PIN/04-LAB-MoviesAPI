using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public MoviesService MoviesService { get; set; }

        public MovieController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = MoviesService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MoviesService.GetMovieById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            var newMovie = MoviesService.AddMovie(movie);
            return Ok(newMovie);
        }

        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id, [FromBody] Movie movie)
        {
            var updated = MoviesService.UpdateMovieById(id, movie);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            var success = MoviesService.DeleteMovie(id);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
