using Absolute_Cinema.Models.Dtos;

namespace Absolute_Cinema.Models.Mappers
{
    public static class MoviesToDto
    {
        public static Movies DtoToMovies(MoviesDto dto)
        {
            return new Movies
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}
