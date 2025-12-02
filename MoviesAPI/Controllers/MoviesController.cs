using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _service;

        public MoviesController(MoviesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _service.GetAllMovies());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _service.GetMovieById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            var newMovie = await _service.AddMovie(movie);
            return Ok(newMovie);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            var ok = await _service.UpdateMovie(movie);
            if (!ok) return NotFound();
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var ok = await _service.DeleteMovie(id);
            if (!ok) return NotFound();

            return Ok("Movie deleted.");
        }
    }
}
