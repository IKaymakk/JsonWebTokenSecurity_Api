using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using Web_UI.Models;

namespace Web_UI.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        // Token'ý session'dan alýyoruz
        var token = HttpContext.Session.GetString("AccessToken");

        if (string.IsNullOrEmpty(token))
        {
            // Token yoksa login sayfasýna yönlendir
            return RedirectToAction("Login", "Login");
        }

        //var client = _httpClientFactory.CreateClient();
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //var response = await client.GetAsync("https://localhost:7119/api/Authorization/protected-data");

        //if (!response.IsSuccessStatusCode)
        //{
        //    // Hatalý token ya da baþka bir sorun olabilir, 401 dönüyor olabilir
        //    return Unauthorized();
        //}

        //var data = await response.Content.ReadAsStringAsync();
        //ViewBag.Data = data;

        return View();
    }
}
