using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using Microsoft.AspNetCore.Http;

namespace MovieApp.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string firstName, string lastName)
        {
            UsersService.RegisterUser(firstName, lastName);

            return RedirectToAction("Index", "Login");
        }
    }
}
