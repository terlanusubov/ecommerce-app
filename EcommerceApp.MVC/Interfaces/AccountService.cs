using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EcommerceApp.MVC.Core;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Core.Responses;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.MVC.Interfaces
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpContext _httpContext;

        public AccountService(ApplicationDbContext context,
                              IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<ServiceResult<LoginResponse>> Login(LoginRequest request, bool isAdmin)
        {
            var user = await _context.Users
                                         .Include(c => c.UserRole)
                                             .Where(c => c.Email == request.Email).FirstOrDefaultAsync();



            if (user == null)
            {
                return ServiceResult<LoginResponse>.ERROR("", "Email or password is incorrect");

            }

            if (isAdmin)
            {
                if (user.UserRoleId != (int)UserRoleEnum.Admin)
                {

                    return ServiceResult<LoginResponse>.ERROR("", "You dont have an access to enter the system.");
                }
            }



            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);

                var hash = sha256.ComputeHash(buffer);

                if (!user.Password.SequenceEqual(hash))
                {

                    return ServiceResult<LoginResponse>.ERROR("", "Email or password is incorrect");
                }
            }




            var response = new LoginResponse();
            response.Name = user.Name;
            response.Surname = user.Surname;
            response.Email = user.Email;
            response.UserId = user.Id;
            response.Role = user.UserRole.Name;
            response.RoleId = user.UserRoleId;

            return ServiceResult<LoginResponse>.OK(response);

        }

        public async Task<ServiceResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var user = await _context.Users
                                    .Include(c=>c.UserRole)
                                        .Where(c => c.Email == request.Email)
                                            .FirstOrDefaultAsync();

            if (user != null) // user is not null
            {
                return ServiceResult<RegisterResponse>.ERROR("", "Bu e-poçt ünvanı artıq qeydiyyatdan keçmişdir.");
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
            //TODO : look at user role

            return ServiceResult<RegisterResponse>.OK(new RegisterResponse
            {
                Name = user.Name,
                UserId = user.Id,
                Surname = user.Surname,
                Role = "Istifadeci",
                RoleId = user.UserRoleId
            });

        }
    }
}

