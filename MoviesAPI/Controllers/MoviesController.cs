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
                return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _moviesService.AddMovie(movie);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            var updatedMovie = _moviesService.UpdateMovie(id, movie);
            if (updatedMovie == null)
                return NotFound();
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _moviesService.DeleteMovie(id);
            return Ok();
        }
    }
}