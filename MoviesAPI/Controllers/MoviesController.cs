using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            MoviesService.AddMovie(movie);
            return Ok();
        }
    }
}
