using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PageDenied()
        {
            return View();
        }
    }
}
