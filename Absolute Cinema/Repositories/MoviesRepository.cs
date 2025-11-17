using Absolute_Cinema.Enteties;
using Absolute_Cinema.Models;
using Absolute_Cinema.Models.Dtos;
using Absolute_Cinema.Models.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Absolute_Cinema.Repositories
{
    public class MoviesRepository
    {

        private readonly MoviesContext moviesContext;

        public MoviesRepository(MoviesContext moviesContext)
        {
            this.moviesContext = moviesContext;
        }

        
        public async Task<Movies> AddAsync(MoviesDto movies)
        {
            if (movies != null)
            {
                var mov = MoviesToDto.DtoToMovies(movies);

                await moviesContext.Movies.AddAsync(mov);
                await moviesContext.SaveChangesAsync();

                return mov;
            }

             throw new Exception();
        }

        public async Task<Movies> GetByIdAsync(int id)
        {
            var movie = await moviesContext.Movies.FindAsync(id);
        
            if (movie != null)
            {
                return movie;
            }
            else 
            {
                throw new NullReferenceException();
            }
        }

        public async Task<List<Movies>> GetMoviesAsync() 
        { 
            var list = await moviesContext.Movies.ToListAsync();
            return list;
        }

        public async Task<Movies> UpdateAsync(MoviesDto movies)
        {
            if (movies is null)
            {
                throw new ArgumentNullException(nameof(movies));
            }

            var existingMovie = await moviesContext.Movies.FindAsync(movies.Id);
            if (existingMovie is null)
            {
                throw new ArgumentException($"Movie with ID {movies.Id} not found");
            }

            existingMovie.Name = movies.Name;
            existingMovie.Description = movies.Description;

            await moviesContext.SaveChangesAsync();

            return existingMovie;
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await moviesContext.Movies.FindAsync(id);

            if (movie is not null)
            {
                moviesContext.Movies.Remove(movie);
                await moviesContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Такого объекта не существует по id: {id}");
            }
        }
    }
}
