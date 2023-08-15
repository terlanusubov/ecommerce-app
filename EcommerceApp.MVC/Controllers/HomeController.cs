using System;
using EcommerceApp.MVC.DTOs.BannerAds;
using EcommerceApp.MVC.DTOs.Categories;
using EcommerceApp.MVC.DTOs.Products;
using EcommerceApp.MVC.DTOs.Sliders;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using EcommerceApp.MVC.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(ApplicationDbContext context,
                             IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

