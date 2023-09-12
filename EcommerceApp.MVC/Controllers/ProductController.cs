using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.MVC.DTOs.Products;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Filters;
using EcommerceApp.MVC.Models;
using EcommerceApp.MVC.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Controllers
{

    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context,
                                IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(int productId, string color = null)
        {

            var hasProduct = await _context.Products.AnyAsync(c => c.Id == productId && c.ProductStatusId != (int)ProductStatus.Deactive);
            if (!hasProduct)
            {
                return RedirectToAction("Index", "Home");
            }




            var product = await _context
                                    .Products
                                    .Include(c => c.Brand)
                                    .Include(c => c.Category)
                                    .Include(c => c.ProductPhotos)
                                    .Where(c => c.Id == productId)
                                    .Select(c => new ProductDto
                                    {
                                        ProductId = c.Id,
                                        ShortDesc = c.ShortDesc,
                                        HasStock = c.HasStock,
                                        AfterDiscountPrice = c.Discount == null ? null : (c.Price - (c.Price * c.Discount / 100)).ToString(),
                                        Price = c.Price.ToString("#.##"),
                                        BrandName = c.Brand.Name,
                                        CategoryName = c.Category.Name,
                                        Description = c.Description,
                                        MainCode = c.MainCode,
                                        Name = c.Name,
                                        ProductCode = c.ProductCode,
                                        MainImage = _configuration["Files:Products"] + c.ProductPhotos.Where(b => b.IsMain == true).Select(b => b.Image).FirstOrDefault(),
                                        Images = c.ProductPhotos.Where(b => b.IsMain == false).Select(b => _configuration["Files:Products"] + b.Image).ToList()

                                    }).FirstOrDefaultAsync();




            var colors = await _context
                .ProductColors
                .Include(c => c.Color)
                .Where(c => c.Product.MainCode == product.MainCode)
                .Select(c => new ProductColorDto
                {
                    MainCode = product.MainCode,
                    Color = c.Color.Name,
                    ProductId = c.ProductId

                }).GroupBy(c => c.Color).ToListAsync();

            product.Colors = colors;

            color = color == null ? product.Colors.Where(c => c.Any(a => a.ProductId == productId))?.FirstOrDefault()?.Key : color;

            var sizes = await _context.ProductSizes
                                        .Include(c => c.Size)
                                        .Where(c => c.Product.MainCode == product.MainCode &&
                                        (color == null || c.Product.ProductColors.Any(a => a.Color.Name == color)))
                                        .Select(c => new ProductSizeDto
                                        {
                                            MainCode = product.MainCode,
                                            Size = c.Size.Name,
                                            ProductId = c.ProductId

                                        }).GroupBy(c => c.Size).ToListAsync();

            product.Sizes = sizes;


            return View(product);
        }


        [HttpPost]
        [Authorize]
        public async Task<JsonResult> AddReview([FromBody]ProductReviewModel request)
        {

            if (!ModelState.IsValid)
            {
                //TODO: update here
                return Json(new
                {
                    status = 400,
                    error = "Validation is not correct"
                });
            }


            var userId = HttpContext.User.Claims.Where(c => c.Type == "Id").FirstOrDefault().Value;
            var name = HttpContext.User.Claims.Where(c => c.Type == "Name").FirstOrDefault().Value;
            var surname = HttpContext.User.Claims.Where(c => c.Type == "Surname").FirstOrDefault().Value;

            var productReview = new ProductReview();

            productReview.ProductId = request.ProductId;
            productReview.ProductReviewStatusId = (int)ProductReviewStatus.Waiting;
            productReview.Review = request.Description;
            productReview.ReviewDate = DateTime.Now;
            productReview.Rate = (int) request.Rating;
            productReview.UserId = Convert.ToInt32(userId);

            await _context.ProductReviews.AddAsync(productReview);
            await _context.SaveChangesAsync();

            return Json(new
            {
                status = 200,
                name = name,
                surname = surname,
                date = productReview.ReviewDate.ToString("dd MM yyyy / hh:mm"),
                image = "/uploads/user.jpeg",
                rate = productReview.Rate
            });
        }
    }
}

