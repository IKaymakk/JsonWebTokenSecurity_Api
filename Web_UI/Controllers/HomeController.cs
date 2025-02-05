using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using Web_UI.Helper;
using Web_UI.Models;

namespace Web_UI.Controllers;

public class HomeController : Controller
{
    private readonly ApiService _apiService;
    private readonly ITokenService _tokenService;


    public HomeController(ApiService apiService, ITokenService tokenService)
    {
        _apiService = apiService;
        _tokenService = tokenService;
    }

    public async Task<IActionResult> Index()
    {
        // Token'ý session'dan alýyoruz
        //var token = HttpContext.Session.GetString("AccessToken");

        //if (string.IsNullOrEmpty(token))
        //{
        //    // Token yoksa login sayfasýna yönlendir
        //    return RedirectToAction("Login", "Login");
        //}

        // API'ye istek yapýyoruz
        var response = await _apiService.GetAsync("https://localhost:7119/api/Authorization/protected-data");

        if (!response.IsSuccessStatusCode)
        {
            // Hatalý token ya da baþka bir sorun olabilir, 401 dönüyor olabilir
            return Unauthorized();
        }

        var data = await response.Content.ReadAsStringAsync();
        ViewBag.Data = data;

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> PostData()
    {
        var token = _tokenService.GetToken();

        if (string.IsNullOrEmpty(token))
        {
            // Token yoksa, kullanýcýyý login sayfasýna yönlendir
            return RedirectToAction("Login", "Login");
        }

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> PostData(string obj)
    {
        var url = "https://localhost:7119/api/Authorization/protected-data-post";
        var response = await _apiService.PostAsync(url, obj);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            ViewBag.Response = responseContent;
        }
        else
        {
            ViewBag.Error = "Bir hata oluþtu: " + response.ReasonPhrase;
        }

        return View();
    }
}
