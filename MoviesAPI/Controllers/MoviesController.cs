using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            MoviesService.AddMovie(movie);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetallMovies()
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

        [HttpPut("id")]
        public IActionResult UpdateMovie([FromQuery] int id, [FromBody] Movie movie)
        {
            var update = MoviesService.UpdateMovie(id, movie);
            return Ok(update);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MoviesService.DeleteMovie(id);
            return Ok();
        }
    }
}

