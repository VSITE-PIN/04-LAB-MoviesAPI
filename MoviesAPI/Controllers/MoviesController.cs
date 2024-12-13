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
		public MoviesService MovieService { get; set; }
		public MoviesController(MoviesService moviesService)
		{
			MovieService = moviesService;
		}
		[HttpPost]
		public IActionResult AddMovie([FromBody] Movie movie)
		{
			MovieService.AddMovie(movie);
			return Ok();
		}
	}
}
