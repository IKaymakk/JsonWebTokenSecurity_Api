using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Web_UI.Controllers;

public class AuthController : Controller
{
    private readonly HttpClient _httpClient;

    public AuthController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7119/api/Authorization", new { username, password });

        if (!response.IsSuccessStatusCode)
            return View("Login"); // Hatalı giriş

        var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

        // Tokeni Session'a kaydet
        HttpContext.Session.SetString("JWToken", tokenResponse.Token);

        return RedirectToAction("Index", "Home");
    }
}
public class TokenResponse
{
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
}