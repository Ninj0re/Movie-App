using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using Microsoft.AspNetCore.Http;
using System;

namespace MovieApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string firstName, string lastName, bool rememberMe)
        {
            var user = UsersService.GetUser(firstName, lastName);

            if (user != null)
            {
                HttpContext.Session.SetString("FirstName", firstName);
                HttpContext.Session.SetString("LastName", lastName);

                if (rememberMe)
                {
                    Response.Cookies.Append("FirstName", firstName, new CookieOptions
                    {
                        Expires = DateTime.Now.AddMonths(1)
                    });
                    Response.Cookies.Append("LastName", lastName, new CookieOptions
                    {
                        Expires = DateTime.Now.AddMonths(1)
                    });
                }

                return Redirect($"/Home/UserHome?firstname={firstName}&lastname={lastName}");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View("Index");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("FirstName");
            Response.Cookies.Delete("LastName");

            return RedirectToAction("Index", "Login");
        }
    }
}
