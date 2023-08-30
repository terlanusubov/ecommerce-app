using System;
namespace EcommerceApp.MVC.DTOs.Products
{
    public class ProductReviewDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Issued { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}

