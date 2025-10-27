using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absolute_Cinema.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

    }
}
