using System;
using EcommerceApp.MVC.DTOs.BannerAds;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Components
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public BannerViewComponent(ApplicationDbContext context,
                                   IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var take = Convert.ToInt32(_configuration["Lists:BannerAds"]);

            //Banners
            var bannerAds = await _context.BannerAds
            .Where(c => c.BannerAdStatusId == (int)BannerStatus.Active)
            .OrderByDescending(c => c.Id)
            .Select(c => new BannerHomeIndexDto
            {
                BannerId = c.Id,
                CategoryId = c.CategoryId,
                Image = _configuration["Files:BannerAds"] + c.Image
            }).Take(take).ToListAsync();

            return View(bannerAds);
        }
    }
}

