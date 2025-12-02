using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesService MoviesService { get; set; }

        public MoviesController(MoviesService moviesService)
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
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            MoviesService.AddMovie(movie);
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie([FromQuery] int id, [FromBody] Movie movie)
        {
            var updated = MoviesService.UpdateMovie(id, movie);
            return Ok(updated);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MoviesService.DeleteMovie(id);
            return Ok();
        }
    }
}
