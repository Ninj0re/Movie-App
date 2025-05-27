using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using MovieApp.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace MovieApp.Controllers
{
    public class MovieInfoController : Controller
    {
        public IActionResult Index(int id)
        {
            var movie = MoviesService.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpGet]
        [Route("MovieInfo/UserHome")]
        public IActionResult UserHome(string firstname, string lastname, int id)
        {
            var movie = MoviesService.GetMovieById(id);
            if (movie == null)
                return NotFound();

            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                return RedirectToAction("Index", "Login");
            }

            var cartMovies = UsersService.GetCartMovies(firstname, lastname);
            bool isInCart = cartMovies.Any(m => m.MovieID == id);

            ViewBag.FirstName = firstname;
            ViewBag.LastName = lastname;
            ViewBag.IsInCart = isInCart;

            return View("UserHome", movie);
        }
    }
}
