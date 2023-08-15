using System;
using EcommerceApp.MVC.DTOs.Categories;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public CategoryMenuViewComponent(ApplicationDbContext context,
                                   IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories.Select(c => new CategoryHomeIndexDto
            {
                CategoryId = c.Id,
                Name = c.Name
            }).ToListAsync();


            return View(categories);
        }
    }
}

