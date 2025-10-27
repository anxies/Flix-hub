using Absolute_Cinema.Models.Dtos;
using Absolute_Cinema.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Absolute_Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesApiController : ControllerBase
    {
        MoviesRepository _moviesRepository;

        public MoviesApiController(MoviesRepository movies) 
        {
            _moviesRepository = movies;
        }

        [HttpGet("allMovies")]
       public IActionResult Get() 
        {
            return Ok(_moviesRepository.GetMovies());
        }

        [HttpGet("moviesById/{id}")]
        public IActionResult GetById(int id)
        {
            var movies = _moviesRepository.GetMovies();
            int index = id - 1;
            if (movies[index].Id > 0 && id <= movies.Count) 
            {
                return Ok(_moviesRepository.GetById(id));
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create([FromBody] MoviesDto dto) 
        {
            
            var movie = _moviesRepository.Add(dto);

            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }
    }
}
