using EcommerceApp.MVC.Interfaces;
using EcommerceApp.MVC.Middlewares;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLogging();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAuthService, AuthService>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(builder.Configuration["Database:Connection"]);
});

var app = builder.Build();

app.UseMyLogging();

//Method extension
app.UseAuthentication();

app.UseAuthorization();


app.UseStaticFiles();


app.MapControllerRoute("admin",
                      "{area:exists}/{controller=Home}/{action=Index}");

app.MapControllerRoute("default",
                      "{controller=Home}/{action=Index}");

app.Run();

