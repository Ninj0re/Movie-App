using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{code}")]
        public IActionResult Index(int code)
        {
            ViewBag.ErrorCode = code;

            string message = code switch
            {
                404 => "Page Not Found",
                500 => "Internal Server Error",
                _ => "An Unexpected Error Occurred"
            };

            ViewBag.ErrorMessage = message;

            return View();
        }
    }
}
