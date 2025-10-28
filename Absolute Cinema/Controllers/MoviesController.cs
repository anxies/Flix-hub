using Absolute_Cinema.Models.Dtos;
using Absolute_Cinema.Repositories;
using Absolute_Cinema.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Absolute_Cinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesRepository _repository;

        public MoviesController(MoviesRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Main(int? id)
        {
            var model = CreateViewMovies(id);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int id) 
        {
            var model = CreateViewMovies(id);

            return View(model);
        }

        private ViewMovies CreateViewMovies(int? id)
        {
            var movies = _repository.GetMovies();

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
