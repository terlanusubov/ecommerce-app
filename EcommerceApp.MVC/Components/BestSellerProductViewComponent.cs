using System;
using EcommerceApp.MVC.DTOs.Categories;
using EcommerceApp.MVC.DTOs.Products;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Components
{
    public class BestSellerProductViewComponent : ViewComponent
    {

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public BestSellerProductViewComponent(ApplicationDbContext context,
                                   IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Categories
            var categories = await _context
                                    .Categories
                                      .Include(c => c.Products)
                                        .Select(c => new CategoryHomeIndexDto
                                        {
                                            CategoryId = c.Id,
                                            Name = c.Name,
                                            Products = c.Products
                                                        .Where(a => a.ProductStatusId == (int)ProductStatus.Home)
                                                            .Select(a => new ProductDto
                                                            {
                                                                Name = a.Name,
                                                                Price = a.Price.ToString("#.##"),
                                                                CategoryName = c.Name,
                                                                ProductId = a.Id,
                                                                //ternory operator
                                                                AfterDiscountPrice = a.Discount == null ? null : (a.Price * a.Discount / 100).ToString(),
                                                                MainImage = _configuration["Files:Products"] + a.ProductPhotos.Where(b => b.IsMain == true).Select(b => b.Image).FirstOrDefault(),
                                                                Images = a.ProductPhotos.Where(b => b.IsMain == false).Select(b => _configuration["Files:Products"] + b.Image).ToList()

                                                            }).ToList()
                                        }).ToListAsync();

            return View(categories);
        }

    }
}

