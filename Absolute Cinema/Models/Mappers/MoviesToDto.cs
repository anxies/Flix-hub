using Absolute_Cinema.Models.Dtos;

namespace Absolute_Cinema.Models.Mappers
{
    public static class MoviesToDto
    {
        public static Movies DtoToMovies(MoviesDto dto)
        {
            var movie = new Movies
            {
                Name = dto.Name,
                Description = dto.Description            
            };
            if (dto.Id.HasValue )
            {
                movie.Id = dto.Id.Value;
            }
            return movie;
        }
    }
}
