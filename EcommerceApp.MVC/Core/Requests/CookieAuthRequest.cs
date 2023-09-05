using System;
namespace EcommerceApp.MVC.Core.Requests
{
    public class CookieAuthRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}

