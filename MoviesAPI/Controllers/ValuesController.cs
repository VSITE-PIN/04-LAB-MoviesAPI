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
        private readonly MoviesService _service;

        public MoviesController(MoviesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllMovies() => Ok(_service.GetAllMovies());

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _service.GetMovieById(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _service.AddMovie(movie);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            _service.UpdateMovie(id, movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _service.DeleteMovie(id);
            return Ok();
        }
    }

}
