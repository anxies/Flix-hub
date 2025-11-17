using Absolute_Cinema.ViewModels;

namespace Absolute_Cinema.Services
{
    public interface IViewMoviesService
    {
        Task<ViewMovies> CreateViewMovies(int? id);
    }
}
