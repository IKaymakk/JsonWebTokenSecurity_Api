using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Web_UI.Models;

namespace Web_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7119/api/Authorization", new { username, password });

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }

            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();

            // Token'ı sessionda saklıyoruz
            HttpContext.Session.SetString("AccessToken", result.Token);

            return RedirectToAction("Index", "Home");
        }
    }
}
public class TokenResponse
{
    public string Token { get; set; }
    public string Expires { get; set; }
}