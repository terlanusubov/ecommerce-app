using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using EcommerceApp.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }


            var user = await _context.Users
                                        .Include(c => c.UserRole)
                                            .Where(c => c.Email == request.Email).FirstOrDefaultAsync();



            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(request);
            }

            if (user.UserRoleId != (int)UserRoleEnum.Admin)
            {
                ModelState.AddModelError("", "You dont have an access to enter the system.");
                return View(request);
            }


            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);

                var hash = sha256.ComputeHash(buffer);

                if (!user.Password.SequenceEqual(hash))
                {
                    ModelState.AddModelError("", "Email or password is incorrect");
                    return View(request);
                }
            }


            var claims = new List<Claim>
                 {
                     new Claim("Name", user.Name),
                     new Claim("Surname", user.Surname),
                     new Claim("Role", user.UserRole.Name),
                     new Claim("RoleId", user.UserRoleId.ToString()),
                     new Claim("Id", user.Id.ToString()),
                 };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
             CookieAuthenticationDefaults.AuthenticationScheme,
           new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home", new { area = "Admin" });

        }
    }
}

