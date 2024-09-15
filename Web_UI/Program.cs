using JsonWebTokenSecurity.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient(); // IHttpClientFactory'yi ekleyin
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(
    JwtBearerDefaults.AuthenticationScheme, x =>
    {
        x.LoginPath = "/Default/SignIn";
        x.LogoutPath = "/Login/SignOut";
        x.AccessDeniedPath = "/Default/PageDenied";
        x.Cookie.SameSite = SameSiteMode.Strict;
        x.Cookie.HttpOnly = true;
        x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        x.Cookie.Name = "CarBookJwt";
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
