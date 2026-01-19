using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

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
            if (movie == null) return NotFound($"Movie with id={id} not found.");
            return Ok(movie);
        }

        
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            var created = MoviesService.AddMovie(movie);
            return Ok(created);
        }

        
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id, [FromBody] MovieVM movieVM)
        {
            var updated = MoviesService.UpdateMovieById(id, movieVM);
            if (updated == null) return NotFound($"Movie with id={id} not found.");
            return Ok(updated);
        }

        
        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            var deleted = MoviesService.DeleteMovie(id);
            if (!deleted) return NotFound($"Movie with id={id} not found.");
            return Ok();
        }
    }
}
