using System;
using EcommerceApp.MVC.DTOs.Sliders;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Components
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public SliderViewComponent(ApplicationDbContext context,
                                   IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Sliders

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


            return View(sliders);
        }
    }
}

