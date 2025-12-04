using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MoviesService _service;

        public MovieController(MoviesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            var newMovie = await _service.AddAsync(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest("Id mismatch");
            await _service.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null) return NotFound();

            await _service.DeleteAsync(movie);
            return NoContent();
        }
    }
}
