﻿using System;
namespace EcommerceApp.MVC.Core.Responses
{
    public class RegisterResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
    }
}

