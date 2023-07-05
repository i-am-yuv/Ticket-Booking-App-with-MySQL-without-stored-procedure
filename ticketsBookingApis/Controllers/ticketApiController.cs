using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticketsBookingApis.Data;
using ticketsBookingApis.Models;

namespace ticketsBookingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ticketApiController : ControllerBase
    {
        private readonly MovieDb _movieContent;
        public ticketApiController(MovieDb movieDb )
        {
            _movieContent = movieDb;
        }

        [HttpPost("moviePost")]
        public IActionResult postMovieDetails([FromBody] MovieModel movieModel  )
        {
            if( movieModel == null )
            {
                return BadRequest();
            }
            else
            {
                _movieContent.movieModels.Add(movieModel);
                _movieContent.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Movie Added Successfully"
                }
                    );
            }
        }

        [HttpGet("all_movies")]
        public IActionResult GetAllMovies()
        {
            var movies = _movieContent.movieModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                postMovieDetails = movies
            }
                );
        }

    }
}
