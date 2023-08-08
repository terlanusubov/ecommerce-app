using System;
using EcommerceApp.MVC.DTOs.BannerAds;
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

            var sliders = await _context
                                    .Sliders
             .Where(c => c.SliderStatusId == (int)SliderStatus.Active)
             .Select(c => new SliderHomeIndexDto
             {
                 Title = c.Title,
                 Slogan = c.Slogan,
                 BackgroundImage = _configuration["Files:Sliders"] + c.BackgroundImage,
                 BottomImage = _configuration["Files:Sliders"] + c.BottomImage,
                 CategoryId = c.CategoryId,
                 TopImage = _configuration["Files:Sliders"] + c.TopImage
             }).ToListAsync();


            var take = Convert.ToInt32(_configuration["Lists:BannerAds"]);
            var bannerAds = await _context.BannerAds
            .Where(c => c.BannerAdStatusId == (int)BannerStatus.Active)
            .OrderByDescending(c => c.Id)
            .Select(c => new BannerHomeIndexDto
            {
                BannerId = c.Id,
                CategoryId = c.CategoryId,
                Image = _configuration["Files:BannerAds"] + c.Image
            }).Take(take).ToListAsync();


            var vm = new HomeIndexVm();

            vm.Sliders = sliders;
            vm.BannerAds = bannerAds;


            return View(vm);
        }
    }
}

