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

namespace EcommerceApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }



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

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel request)
        {


            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = await _context.Users.Where(c => c.Email == request.Email).FirstOrDefaultAsync();

            if (user != null) // user is not null
            {
                ModelState.AddModelError("", "Bu e-poçt ünvanı artıq qeydiyyatdan keçmişdir.");
                return View(request);
            }


            user = new User();
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Email = request.Email;
            user.RegisterDate = DateTime.Now;
            user.UserRoleId = (int)UserRoleEnum.User;
            user.Created = DateTime.Now;
            user.Updated = DateTime.Now;
            user.UserStatusId = (int)UserStatus.Active;


            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);

                var hash = sha256.ComputeHash(buffer);

                user.Password = hash;
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
        }

    }
}

