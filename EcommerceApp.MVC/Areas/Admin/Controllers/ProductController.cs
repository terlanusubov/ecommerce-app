using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.MVC.Areas.Admin.DTOs;
using EcommerceApp.MVC.Areas.Admin.Models;
using EcommerceApp.MVC.DTOs.Categories;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Filters;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ProductController(ApplicationDbContext context,
                                IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1)
        {
            var products = await _context.Products
                                                .Include(c => c.Category)
                                                .Include(c => c.ProductPhotos)
                                                .OrderByDescending(c => c.Id)
                                                    .Select(c => new ProductListDto
                                                    {
                                                        Name = c.Name,
                                                        ProductStatusId = c.ProductStatusId,
                                                        CategoryName = c.Category.Name,
                                                        Created = c.Created,
                                                        Discount = c.Discount,
                                                        Image = _configuration["Files:Products"] + c.ProductPhotos.Where(a => a.IsMain).Select(a => a.Image).FirstOrDefault(),
                                                        Price = c.Price,
                                                        ProductId = c.Id

                                                    })
                                                    .Skip((page - 1) * 10)
                                                    .Take(10)
                                                    .ToListAsync();


            var count = await _context.Products.CountAsync();

            var pageCount = Math.Ceiling(count / (decimal)10);

            ViewBag.Pagination = new PaginationModel
            {
                Url = "/admin/Product/List",
                Count = pageCount,
                Page = page
            };

            return View(products);
        }



        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var vm = await FillProductAdd();
            return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> Add(ProductAddVm request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var vm = await FillProductAdd(request);
                    return View(vm);
                }


                await _context.Database.BeginTransactionAsync();

                var product = new Product();

                product.BrandId = request.Product.BrandId;
                product.CategoryId = request.Product.CategoryId;
                product.Name = request.Product.Name;
                product.Created = DateTime.Now;
                product.Updated = DateTime.Now;
                product.Discount = request.Product.Discount;
                product.Price = request.Product.Price;
                product.Description = request.Product.Description;
                product.ShortDesc = request.Product.ShortDesc;
                product.StockCount = request.Product.StockCount;
                product.MainCode = "test";
                product.ProductCode = Guid.NewGuid().ToString();
                product.IsMain = false;
                product.HasStock = true;
                product.ProductStatusId = request.Product.StatusId;


                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                var productColor = new ProductColor();

                productColor.ColorId = request.Product.ColorId;
                productColor.ProductId = product.Id;

                await _context.ProductColors.AddAsync(productColor);



                var productSize = new ProductSize();

                productSize.SizeId = request.Product.SizeId;
                productSize.ProductId = product.Id;

                await _context.ProductSizes.AddAsync(productSize);



                //MAIN IMAGE
                string mainImageFileName = Guid.NewGuid().ToString() + request.Product.MainImage.FileName;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products", mainImageFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await request.Product.MainImage.CopyToAsync(stream);
                }

                var productPhoto = new ProductPhoto();

                productPhoto.Image = mainImageFileName;
                productPhoto.IsMain = true;
                productPhoto.ProductId = product.Id;

                await _context.ProductPhotos.AddAsync(productPhoto);
                //END MAIN IMAGE

                //IMAGES
                foreach (var image in request.Product.Images)
                {
                    string imageFileName = Guid.NewGuid().ToString() + image.FileName;

                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products", mainImageFileName);

                    using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    var pPhoto = new ProductPhoto();

                    pPhoto.Image = mainImageFileName;
                    pPhoto.IsMain = false;
                    pPhoto.ProductId = product.Id;

                    await _context.ProductPhotos.AddAsync(pPhoto);
                }


                //END IMAGES

                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();



                return RedirectToAction("List", "Product");
            }
            catch (Exception exp)
            {
                await _context.Database.RollbackTransactionAsync();
                ModelState.AddModelError("", "Internal Server error");
                return View(request);
            }
        }



        private async Task<ProductAddVm> FillProductAdd(ProductAddVm vm = null)
        {
            var colors = await _context.Colors.Select(c => new ColorDto
            {
                ColorId = c.Id,
                Name = c.Name
            }).ToListAsync();

            var sizes = await _context.Sizes.Select(c => new SizeDto
            {
                SizeId = c.Id,
                Name = c.Name
            }).ToListAsync();

            var brands = await _context.Brands.Select(c => new BrandDto
            {
                BrandId = c.Id,
                Name = c.Name
            }).ToListAsync();

            var categories = await _context.Categories.Select(c => new CategoryListDto
            {
                CategoryId = c.Id,
                Name = c.Name
            }).ToListAsync();

            var statuses = Enum.GetNames(typeof(ProductStatus)).ToList();



            if (vm == null)
            {
                vm = new ProductAddVm();
            }

            vm.Colors = colors;
            vm.Categories = categories;
            vm.Brands = brands;
            vm.Sizes = sizes;
            vm.Statuses = statuses;

            return vm;
        }
    }
}

