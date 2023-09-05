using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EcommerceApp.MVC.Core;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Interfaces;
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
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _accountService.Login(request, true);

            if (result.Status != 200)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }



            return RedirectToAction("Index", "Home", new { area = "Admin" });

        }
    }
}

