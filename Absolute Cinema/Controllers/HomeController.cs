using System.Diagnostics;
using Absolute_Cinema.Enteties;
using Absolute_Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Absolute_Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesContext moviesContext;

        public HomeController(ILogger<HomeController> logger, MoviesContext moviesContext)
        {
            this.moviesContext = moviesContext;
            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {
            var movies = await moviesContext.Movies.ToListAsync();
            return View(movies);
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
