using Absolute_Cinema.Models.Dtos;
using Absolute_Cinema.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absolute_Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        MoviesRepository _moviesRepository;

        public MoviesController(MoviesRepository movies) 
        {
            _moviesRepository = movies;
        }

        [HttpGet("show")]
       public IActionResult Get() 
        {
            return Ok(_moviesRepository.GetMovies());
        }

        [HttpGet("show/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_moviesRepository.GetById(id));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] MoviesDto dto) 
        {
            
            var movie = _moviesRepository.Add(dto);

            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }
    }
}
