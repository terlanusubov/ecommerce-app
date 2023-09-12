using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.MVC.Core.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "E-poçt boş qala bilməz.")]
        [EmailAddress(ErrorMessage = "E-poçt düzgün deyil.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə boş qala bilməz.")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}

