using System;
using EcommerceApp.MVC.Core;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Core.Responses;
using EcommerceApp.MVC.ViewModels.Account;

namespace EcommerceApp.MVC.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult<LoginResponse>> Login(LoginRequest request, bool isAdmin = false);

        Task<ServiceResult<RegisterResponse>> Register(RegisterRequest request);

    }
}

