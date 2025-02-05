using FluentValidation.AspNetCore;
using JsonWebTokenSecurity.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web_UI.Helper;
using Web_UI.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient(); // HttpClient ekle
builder.Services.AddSession(); // Session yönetimi
builder.Services.AddHttpContextAccessor(); // HttpContext eriþimi için
builder.Services.AddScoped<ApiService>();  // ApiService'i ekliyoruz
builder.Services.AddScoped<ITokenService, TokenService>();

// JWT Authentication ekle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, // Güvenlik için ekledim
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });

// Authorization ekle
builder.Services.AddAuthorization();

// MVC'yi ve FluentValidation'ý ekle
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<TokenValidationActionFilter>();  // Filtreyi ekliyoruz
})
.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SignInValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware sýrasý önemli!
app.UseSession();         // Session yönetimi burada olmalý
app.UseAuthentication();  // Kullanýcý kimlik doðrulama (JWT)
app.UseAuthorization();   // Yetkilendirme iþlemleri

// Varsayýlan route tanýmla
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
