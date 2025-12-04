using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _moviesService;

        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            var movies = await _moviesService.GetAllAsync();
            return Ok(movies);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            var movie = await _moviesService.GetByIdAsync(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        
        [HttpPost]
        public async Task<ActionResult<Movie>> Create(Movie movie)
        {
            var created = await _moviesService.AddAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            var success = await _moviesService.UpdateAsync(id, movie);
            if (!success)
                return NotFound();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _moviesService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
