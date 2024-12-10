using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    public class MovieController : Controller
    {
        public MoviesService MoviesService { get; set; }
        public MovieController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if (movie is null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            MoviesService.AddMovie(movie);
            return Ok();
        }
    }
}
