using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage(int code)
        {
            if(code == 404) {
                return View("NotFound");
            }
            return View(code);
        }
    }
}
