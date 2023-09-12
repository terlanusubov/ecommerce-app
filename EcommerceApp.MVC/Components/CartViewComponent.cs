using EcommerceApp.MVC.DTOs.Carts;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;
        private readonly ApplicationDbContext _context;
        public CartViewComponent(IHttpContextAccessor httpContextAccessor,
                                 ApplicationDbContext context,
                                 IConfiguration configuration)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _configuration = configuration;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_httpContext.User.Identity.IsAuthenticated)
            {
              
                return View(new CartDto());
            }

            var userId =  _httpContext.User.Claims.Where(c => c.Type == "Id").FirstOrDefault().Value;


            var cart = await _context.Carts
                                         .Include(c => c.CartDetails)
                                         .ThenInclude(c=>c.Product)
                                         .ThenInclude(c=>c.ProductPhotos)
                                        .Where(c =>
                                        c.UserId == Convert.ToInt32(userId)
                                        &&
                                        c.CartStatusId == (int)CartStatus.Active)
                                        .Select(c => new CartDto
                                        {
                                            TotalPrice= c.TotalPrice,
                                            Count = c.CartDetails.Sum(a=>a.Count),
                                            CartDetails = c.CartDetails.Select(a=> new CartDetailDto
                                            {
                                                Name = a.Product.Name,
                                                ProductId = a.ProductId,
                                                AfterDiscountPrice = a.Product.Discount == null ? null : (a.Product.Price - (a.Product.Price * a.Product.Discount / 100)).ToString(),
                                                Image =   _configuration["Files:Products"] + a.Product.ProductPhotos.Where(b => b.IsMain == true).Select(b => b.Image).FirstOrDefault()
                                                ,
                                                Price = a.Price
                                            }).ToList()

                                        }).FirstOrDefaultAsync();

            return View(cart ?? new CartDto());
                                         
        } 
    }
}
