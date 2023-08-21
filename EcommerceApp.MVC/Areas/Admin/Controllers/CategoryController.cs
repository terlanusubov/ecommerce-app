using System;
using EcommerceApp.MVC.Areas.Admin.Models;
using EcommerceApp.MVC.DTOs.Categories;
using EcommerceApp.MVC.Filters;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> List(int page = 1)
        {
            var categories = await _context.Categories.OrderByDescending(c => c.Id).Select(c => new CategoryListDto
            {
                CategoryId = c.Id,
                Name = c.Name

            }).Skip((page - 1) * 10).Take(10).ToListAsync();


            var count = await _context.Categories.CountAsync();

            var pageCount = Math.Ceiling(count / (decimal)10);

            ViewBag.Pagination = new PaginationModel
            {
                Url = "/admin/Category/List",
                Count = pageCount,
                Page = page
            };

            return View(categories);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }


            var category = await _context.Categories.Where(c => c.Name.ToLower() == request.Name.ToLower()).FirstOrDefaultAsync();

            if (category != null)
            {
                ModelState.AddModelError("", "There is already category like that.");
                return View(request);
            }


            category = new Category();

            category.Name = request.Name;
            category.Created = DateTime.Now;
            category.Updated = DateTime.Now;


            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Category");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int categoryId)
        {
            var category = await _context
                                    .Categories
                                    .Where(c => c.Id == categoryId)

                                    .Select(c => new CategoryEditModel
                                    {
                                        Name = c.Name,
                                        CategoryId = c.Id
                                    }).FirstOrDefaultAsync();

            if (category == null)
            {
                return RedirectToAction("List", "Category");
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditModel request)
        {

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var category = await _context
                                    .Categories
                                    .Where(c => c.Id == request.CategoryId)
                                   .FirstOrDefaultAsync();

            if (category == null)
            {
                ModelState.AddModelError("", "There is not any category like that");
                return View(request);
            }



            var wantToAddCategory = await _context.Categories.Where(c => c.Name.ToLower() == request.Name.ToLower() && c.Id != request.CategoryId).FirstOrDefaultAsync();

            if (wantToAddCategory != null)
            {
                ModelState.AddModelError("", "There is already category like that");
                return View(request);
            }


            category.Name = request.Name;
            category.Updated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Category");

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var category = await _context
                                    .Categories
                                    .Where(c => c.Id == categoryId)
                                   .FirstOrDefaultAsync();

            if (category == null)
            {
                return RedirectToAction("List", "Category");
            }


            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Category");

        }
    }
}

