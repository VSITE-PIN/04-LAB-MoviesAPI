using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MoviesService _moviesService;

        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        // 1. DOHVATI SVE
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_moviesService.GetAllMovies());
        }

        // 2. DOHVATI JEDAN
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var film = _moviesService.GetMovieById(id);
            if (film == null) return NotFound();
            return Ok(film);
        }

        // 3. DODAJ
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _moviesService.AddMovie(movie);
            return Ok();
        }

        // 4. AŽURIRAJ
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            var azuriraniFilm = _moviesService.UpdateMovie(id, movie);
            if (azuriraniFilm == null) return NotFound();
            return Ok(azuriraniFilm);
        }

        // 5. OBRIŠI
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _moviesService.DeleteMovie(id);
            return Ok();
        }
    }
}