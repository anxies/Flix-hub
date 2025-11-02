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

        
        public Movies Add(MoviesDto movies)
        {
            if (movies != null)
            {
                var mov = MoviesToDto.DtoToMovies(movies);

                mov.Id = 0;

                moviesContext.Movies.Add(mov);
                moviesContext.SaveChanges();

                return mov;
            }

             throw new Exception();
        }

        public Movies GetById(int id)
        {
            var movie = moviesContext.Movies.Find(id);

            if (movie != null)
            {
                return movie;
            }
            else 
            {
                throw new NullReferenceException();
            }
        }

        public List<Movies> GetMovies() 
        { 
            return moviesContext.Movies.ToList();
        }

        public Movies Update(MoviesDto movies)
        {
            if (movies is null)
            {
                throw new ArgumentNullException(nameof(movies));
            }

            var existingMovie = moviesContext.Movies.Find(movies.Id);
            if (existingMovie is null)
            {
                throw new ArgumentException($"Movie with ID {movies.Id} not found");
            }

            existingMovie.Name = movies.Name;
            existingMovie.Description = movies.Description;

            moviesContext.SaveChanges();
            return existingMovie;
        }

        public void Delete(int id)
        {
            var movie = moviesContext.Movies.Find(id);
            if (movie is not null)
            {
                moviesContext.Movies.Remove(movie);
                moviesContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Такого объекта не существует по id: {id}");
            }
        }
    }
}
