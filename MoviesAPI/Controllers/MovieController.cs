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

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
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

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            var updatedMovie = MoviesService.UpdateMovieById(id, movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            MoviesService.DeleteMovie(id);
            return Ok();
        }
    }
}
