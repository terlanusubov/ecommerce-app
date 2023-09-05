﻿using System;
namespace EcommerceApp.MVC.Core.Responses
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
    }
}

