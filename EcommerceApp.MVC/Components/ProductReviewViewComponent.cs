using System;
using EcommerceApp.MVC.DTOs.Products;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Components
{
    public class ProductReviewViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpContext _httpContext;
        public ProductReviewViewComponent(ApplicationDbContext context,
                                          IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;

        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var idClaim = _httpContext.User.Claims.Where(c => c.Type == "Id").FirstOrDefault();

            var userId = idClaim != null ? Convert.ToInt32(idClaim.Value) : 0;

            var productReviews = await _context
                                        .ProductReviews
                                        .Include(c => c.User)
                                        .Where(c =>

                                        c.ProductId == productId

                                        &&
                                        (

                                        (c.ProductReviewStatusId == (int)ProductReviewStatus.Accepted)

                                        ||

                                        (c.UserId == userId
                                        && c.ProductReviewStatusId != (int)ProductReviewStatus.Blocked))

                                         )
                                        .OrderByDescending(c => c.Id)
                                        .Select(c => new ProductReviewDto
                                        {
                                            Name = c.User.Name,
                                            Surname = c.User.Surname,
                                            UserId = c.UserId,
                                            Description = c.Review,
                                            Issued = c.ReviewDate,
                                            Rating = c.Rate,
                                            ProductId = c.ProductId,
                                            Image = "/uploads/user.jpeg"
                                        })
                                        .ToListAsync();

            return View(productReviews);
        }
    }
}

