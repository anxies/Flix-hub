using Absolute_Cinema.Enteties;
using Absolute_Cinema.Models;
using Absolute_Cinema.Repositories;
using Absolute_Cinema.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Absolute_Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesContext moviesContext;
        private readonly MoviesRepository moviesRepository;
        public HomeController(ILogger<HomeController> logger, MoviesContext moviesContext, MoviesRepository moviesRepository)
        {
            this.moviesContext = moviesContext;
            _logger = logger;
            this.moviesRepository = moviesRepository;
        }


        public async Task<IActionResult> Index(int? id)
        {
            var movies = moviesRepository.GetMovies();

            var model = new ViewMovies
            {
                Movies = movies,
                SelectedMovie = null
            };
            if (id.HasValue)
            {
                model.SelectedMovie =  model.Movies.FirstOrDefault(m => id == m.Id);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
