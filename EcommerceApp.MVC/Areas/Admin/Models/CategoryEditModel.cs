using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.MVC.Areas.Admin.Models
{
    public class CategoryEditModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(300)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}

