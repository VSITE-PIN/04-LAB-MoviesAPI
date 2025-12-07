using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MovieController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_moviesService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _moviesService.GetById(id);
            if (movie == null) return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            var created = _moviesService.Add(movie);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();

            bool updated = _moviesService.Update(id, movie);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _moviesService.Delete(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
