using Absolute_Cinema.Repositories;
using Absolute_Cinema.ViewModels;
using NuGet.Protocol.Core.Types;

namespace Absolute_Cinema.Services
{
    public class ViewMoviesService: IViewMoviesService
    {
        private readonly MoviesRepository _repository;
        public ViewMoviesService(MoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ViewMovies> CreateViewMovies(int? id)
        {
            var movies = await _repository.GetMoviesAsync();

            var model = new ViewMovies
            {
                Movies = movies,
                SelectedMovie = null
            };
            if (id.HasValue)
            {
                model.SelectedMovie = model.Movies.FirstOrDefault(m => id == m.Id);
            }

            return model;
        }
    }
}
