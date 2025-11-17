using Absolute_Cinema.Models.Dtos;
using Absolute_Cinema.Repositories;
using Absolute_Cinema.Services;
using Absolute_Cinema.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Absolute_Cinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesRepository _repository;
        private readonly IViewMoviesService _viewMovies;

        public MoviesController(MoviesRepository repository, IViewMoviesService viewMovies)
        {
            _repository = repository;
            _viewMovies = viewMovies;
        }

        public async Task<ActionResult> Main(int? id)
        {
            var model = await _viewMovies.CreateViewMovies(id);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> Update(int id) 
        {
            var model = await _viewMovies.CreateViewMovies(id);

            return View(model);
        }

        
    }
}
