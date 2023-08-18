using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(builder.Configuration["Database:Connection"]);
});

var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();


app.MapControllerRoute("admin",
                      "{area:exists}/{controller=Home}/{action=Index}");

app.MapControllerRoute("default",
                      "{controller=Home}/{action=Index}");

app.Run();