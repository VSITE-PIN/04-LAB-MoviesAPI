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
        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MoviesService.GetAllMovies();
            return Ok(allMovies);
        }
        [HttpGet("id")]
        public IActionResult GetMoviesById([FromQuery] int id)
        {
            var movie = MoviesService.GetMovieById(id);
            return Ok(movie);
        }
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id, [FromBody] Movie movie)
        {
            var updatedMovie = MoviesService.UpdateMovieById(id, movie);
            return Ok(updatedMovie);
        }
        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MoviesService.DeleteMovie(id); return Ok();
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            MoviesService.AddMovie(movie);
            return Ok();
        }
    }
}
