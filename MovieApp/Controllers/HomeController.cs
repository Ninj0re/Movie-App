using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using MovieApp.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        [Route("Home")]
        public IActionResult Index()
        {
            var movies = MoviesService.GetAllMovies();
            return View("Index", movies);
        }

        [HttpGet]
        [Route("Home/UserHome")]
        public IActionResult UserHome()
        {
            string firstName = HttpContext.Session.GetString("FirstName");
            string lastName = HttpContext.Session.GetString("LastName");

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                firstName = Request.Cookies.ContainsKey("UserFirstName") ? Request.Cookies["UserFirstName"] : null;
                lastName = Request.Cookies.ContainsKey("UserLastName") ? Request.Cookies["UserLastName"] : null;

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    HttpContext.Session.SetString("FirstName", firstName);
                    HttpContext.Session.SetString("LastName", lastName);
                }
            }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.UserInfo = $"{firstName} {lastName}";

            var allMovies = MoviesService.GetAllMovies();
            ViewBag.NowPlaying = allMovies.Where(m => !m.ComingSoon).ToList();
            ViewBag.ComingSoon = allMovies.Where(m => m.ComingSoon).ToList();
            ViewBag.TopRated = allMovies.OrderByDescending(m => m.IMDBRating).Take(5).ToList();

            return View("UserHome", allMovies);
        }
    }
}
