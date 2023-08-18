using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceApp.MVC.Filters
{
    public class MyAuth : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string Role;
        public MyAuth(string role)
        {
            Role = role;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {

            bool isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { area = "Admin" });

                return;
            }


            var roleClaim = context.HttpContext.User.Claims.Where(c => c.Type == "Role").FirstOrDefault();

            if (roleClaim == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { area = "Admin" });

                return;
            }


            if (roleClaim.Value != Role)
            {

                context.Result = new RedirectToActionResult("Login", "Account", new { area = "Admin" });
                return;

            }


        }
    }
}

