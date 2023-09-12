using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.MVC.ViewModels.Product
{
    public class ProductReviewModel
    {

        [Required]
        public string Description { get; set; }
        [Required]
        public int? Rating { get; set; }
        public int ProductId { get; set; }
    }
}

