using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Helper
{
    public class TokenValidationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var token = context.HttpContext.Session.GetString("AccessToken");

            //// Kullanıcı zaten Login sayfasındaysa, bir döngü oluşmaması için kontrol ekle
            //var isLoginPage = context.HttpContext.Request.Path.ToString().Contains("/Login");

            //if (string.IsNullOrEmpty(token) && !isLoginPage)
            //{
            //    context.Result = new RedirectToActionResult("Login", "Login", null);
            //}
        }


        public void OnActionExecuted(ActionExecutedContext context) { }
    }

}
