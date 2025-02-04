using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Web_UI.Helper
{
    public class HttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpClientService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            var client = _httpClientFactory.CreateClient();
            var token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken"); // Session'dan token al

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token); // Header'a token'ı ekle
            }

            return await client.GetAsync(uri); // API'ye istek gönder
        }
    }
}
