using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.MVC.Core.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Ad boş qala bilməz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş qala bilməz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "E-poçt boş qala bilməz.")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt daxil edin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə boş qala bilməz.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Təkrar şifrə boş qala bilməz.")]
        [Compare("Password", ErrorMessage = "Təkrar şifrə düzgün deyil.")]
        public string ConfirmPassword { get; set; }
    }
}

