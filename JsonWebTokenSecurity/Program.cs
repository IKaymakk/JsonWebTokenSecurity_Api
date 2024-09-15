using JsonWebTokenSecurity.Models;
using JsonWebTokenSecurity.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JsonWebTokenSecurity._DataAccessLayer.Abstract;
using JsonWebTokenSecurity._DataAccessLayer.Concrete;
using JsonWebTokenSecurity._DataAccessLayer.Context;
using JsonWebTokenSecurity._BusinessLayer.Abstract;
using JsonWebTokenSecurity._BusinessLayer.Concrete;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtDefaults.Issuer,
            ValidAudience = JwtDefaults.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtDefaults.Key))
        };
    });

builder.Services.AddDbContext<SQLContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IAppRoleRepository, AppRoleRepository>();
builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppRoleService, AppRoleManager>();


//builder.Services.Configure<JwtAyarlari>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
