using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Interfaces;
using EcommerceApp.MVC.Models;
using EcommerceApp.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAuthService _authService;
        public AccountController(IAccountService accountService,
                                IAuthService authService)
        {
            _accountService = accountService;
            _authService = authService;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginRequest
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _accountService.Login(request);

            if (result.Status != 200)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }


            var cookiAuthModel = new CookieAuthRequest();
            cookiAuthModel.Name = result.Response.Name;
            cookiAuthModel.Surname = result.Response.Surname;
            cookiAuthModel.UserId = result.Response.UserId;
            cookiAuthModel.Role = result.Response.Role;
            cookiAuthModel.RoleId = result.Response.RoleId;

            var cookieAuthResult = await _authService.CookieAuth(cookiAuthModel);

            if (cookieAuthResult.Status != 200)
            {
                foreach (var item in cookieAuthResult.Errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }


            if(request.ReturnUrl != null)
                return LocalRedirect(request.ReturnUrl);
            else
                return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterRequest
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _accountService.Register(request);
            if (result.Status != 200)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            var cookiAuthModel = new CookieAuthRequest();
            cookiAuthModel.Name = result.Response.Name;
            cookiAuthModel.Surname = result.Response.Surname;
            cookiAuthModel.UserId = result.Response.UserId;
            cookiAuthModel.Role = result.Response.Role;
            cookiAuthModel.RoleId = result.Response.RoleId;

            var cookieAuthResult = await _authService.CookieAuth(cookiAuthModel);

            if(cookieAuthResult.Status != 200)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }


            if (request.ReturnUrl != null)
                return LocalRedirect(request.ReturnUrl);
            else
                return RedirectToAction("Index", "Home");

        }

    }
}

