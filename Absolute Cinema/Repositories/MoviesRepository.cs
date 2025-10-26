using Absolute_Cinema.Enteties;
using Absolute_Cinema.Models;
using Absolute_Cinema.Models.Dtos;
using Absolute_Cinema.Models.Mappers;

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
                moviesContext.Movies.Add(MoviesToDto.DtoToMovies(movies));
                moviesContext.SaveChanges();

                return MoviesToDto.DtoToMovies(movies);
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
        
    }
}
