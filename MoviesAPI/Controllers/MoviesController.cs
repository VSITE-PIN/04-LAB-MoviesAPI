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

        // DOHVAĆANJE SVIH FILMOVA
        // GET: api/movies
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = MoviesService.GetAllMovies();
            return Ok(movies);
        }

        // DOHVAĆANJE JEDNOG FILMA PREKO ID-a
        // GET: api/movies/id?id=1
        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MoviesService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // DODAVANJE FILMA
        // POST: api/movies
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie object is null.");
            }

            var newMovie = MoviesService.AddMovie(movie);
            return Ok(newMovie);
        }

        // AŽURIRANJE FILMA
        // PUT: api/movies/id?id=1
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id, [FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie object is null.");
            }

            var updatedMovie = MoviesService.UpdateMovieById(id, movie);

            if (updatedMovie == null)
            {
                return NotFound();
            }

            return Ok(updatedMovie);
        }

        // BRISANJE FILMA
        // DELETE: api/movies/id?id=1
        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            var deleted = MoviesService.DeleteMovie(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
