using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using MovieApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MovieApp.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        [Route("Cart/UserHome")]
        public IActionResult UserHome(string firstname, string lastname)
        {
            string firstName = HttpContext.Session.GetString("FirstName") ?? Request.Cookies["FirstName"];
            string lastName = HttpContext.Session.GetString("LastName") ?? Request.Cookies["LastName"];

            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname))
            {
                firstName = firstname;
                lastName = lastname;
                HttpContext.Session.SetString("FirstName", firstName);
                HttpContext.Session.SetString("LastName", lastName);
            }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return RedirectToAction("Index", "Login");
            }

            var cartMovies = UsersService.GetCartMovies(firstName, lastName) ?? new List<Movies>();

            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;

            return View("Index", cartMovies);
        }

        [HttpPost]
        public IActionResult AddToCart(int movieId)
        {
            string firstName = HttpContext.Session.GetString("FirstName") ?? Request.Cookies["FirstName"];
            string lastName = HttpContext.Session.GetString("LastName") ?? Request.Cookies["LastName"];

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                var movie = MoviesService.GetMovieById(movieId);
                if (movie != null)
                {
                    bool isAdded = UsersService.AddMovieToCart(firstName, lastName, movie);

                    return Json(new
                    {
                        success = isAdded,
                        message = isAdded ? "Movie is Added to Cart" : "Movie is Already in the Cart"
                    });
                }
            }

            return Json(new { success = false, message = "Failed to Add Movie" });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int movieId)
        {
            string firstName = HttpContext.Session.GetString("FirstName") ?? Request.Cookies["FirstName"];
            string lastName = HttpContext.Session.GetString("LastName") ?? Request.Cookies["LastName"];

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                UsersService.RemoveMovieFromCart(firstName, lastName, movieId);
            }

            return RedirectToAction("UserHome", new { firstname = firstName, lastname = lastName });
        }
    }
}
