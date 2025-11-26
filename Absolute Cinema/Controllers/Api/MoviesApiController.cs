using Absolute_Cinema.Models.Dtos;
using Absolute_Cinema.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Absolute_Cinema.Controllers.Api
{
    [Route($"[controller]")]
    [ApiController]
    public class MoviesApiController : ControllerBase
    {
        private readonly MoviesRepository _moviesRepository;

        public MoviesApiController(MoviesRepository movies) 
        {
            _moviesRepository = movies;
        }

        [HttpGet("allMovies")]
       public async Task<IActionResult> Get() 
        {
            var movies = await _moviesRepository.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("moviesById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movies = await _moviesRepository.GetMoviesAsync();
            int index = id - 1;
            if (movies[index].Id > 0 && id <= movies.Count) 
            {
                return Ok(_moviesRepository.GetByIdAsync(id));
            }
            return BadRequest();
        }
               
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MoviesDto dto) 
        {
            Console.WriteLine(dto);
            var movie = await _moviesRepository.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MoviesDto dto) 
        { 
            await _moviesRepository.UpdateAsync(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _moviesRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
