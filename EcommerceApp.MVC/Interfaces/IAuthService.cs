using System;
using EcommerceApp.MVC.Core;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Core.Responses;

namespace EcommerceApp.MVC.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult<CookieAuthResponse>> CookieAuth(CookieAuthRequest request);
    }
}

