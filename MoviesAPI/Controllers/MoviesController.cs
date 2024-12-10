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

        [HttpPost]
        public IActionResult AddMovie([FromBody] MoviesVM movies)
        {
            MoviesService.AddMovie(movies);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MoviesService.GetAllMovies();
            return Ok(allMovies);
        }

        [HttpGet]
        public IActionResult GetMoviesById([FromQuery] int id)
        {
            var movies = MoviesService.GetMovieById(id);
            return Ok(movies);
        }

        [HttpPut("id")]
        public IActionResult UpdateMoviesById([FromQuery] int id, [FromBody] MoviesVM moviesVm)
        {
            var updatedMovies = MoviesService.UpdateMoviesById(id, moviesVm);
            return Ok(updatedMovies);
        }
    }
}
