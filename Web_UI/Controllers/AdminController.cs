using Microsoft.AspNetCore.Mvc;
using Web_UI.Helper;

namespace Web_UI.Controllers;

public class AdminController : Controller
{
    /// <summary>
    /// Sadece Admin rolüne sahip kullanıcılar bu sayfaya erişebilir.
    /// </summary>
    public IActionResult Index()
    {
        var token = HttpContext.Session.GetString("JWToken");

        if (string.IsNullOrEmpty(token) || !JwtHelper.GetRoles(token).Contains("Admin"))
        {
            return RedirectToAction("AccessDenied", "Auth"); // Yetkin yoksa yönlendir.
        }

        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

}
