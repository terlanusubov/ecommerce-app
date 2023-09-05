using System;
using System.Security.Claims;
using EcommerceApp.MVC.Core;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Core.Responses;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EcommerceApp.MVC.Interfaces
{
    public class AuthService : IAuthService
    {
        private readonly HttpContext _httpContext;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        public async Task<ServiceResult<CookieAuthResponse>> CookieAuth(CookieAuthRequest request)
        {
            var claims = new List<Claim>
            {
                new Claim("Name", request.Name),
                new Claim("Surname", request.Surname),
                     new Claim("Role", request.Role),
                     new Claim("RoleId", request.RoleId.ToString()),
                     new Claim("Id", request.UserId.ToString()),
                 };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _httpContext.SignInAsync(
             CookieAuthenticationDefaults.AuthenticationScheme,
           new ClaimsPrincipal(claimsIdentity));


            return ServiceResult<CookieAuthResponse>.OK(new CookieAuthResponse());
        }
    }
}

