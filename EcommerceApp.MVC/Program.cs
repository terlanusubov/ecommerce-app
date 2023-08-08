using EcommerceApp.MVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(builder.Configuration["Database:Connection"]);
});

var app = builder.Build();



app.UseStaticFiles();

app.MapControllerRoute("default",
                      "{controller=Home}/{action=Index}");


app.Run();