using System;
using System.Security.Cryptography;
using System.Text;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using EcommerceApp.MVC.ViewModels.Account;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel request)
        {
            var user = await _context.Users.Where(c => c.Email == request.Email).FirstOrDefaultAsync();



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


            //TODO: Cookie auth

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            var user = new User();
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Email = request.Email;
            user.RegisterDate = DateTime.Now;
            user.UserRoleId = (int)UserRoleEnum.User;
            user.Created = DateTime.Now;
            user.Updated = DateTime.Now;


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

